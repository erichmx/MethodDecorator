using Mono.Cecil;
using System;
using System.Linq;

namespace MethodDecorator.Fody {

    public static class TypeReferenceExtensions {

        public static bool Implements(this TypeDefinition typeDefinition, System.Type type) {
            if (type.IsInterface == false) {
                throw new InvalidOperationException("The <type> argument (" + type.Name + ") must be an Interface type.");
            }

            var referenceFinder = new ReferenceFinder(typeDefinition.Module);
            var baseTypeDefinition = referenceFinder.GetTypeReference(type);

            return typeDefinition.Implements(baseTypeDefinition);
        }

        public static bool Implements(this TypeDefinition typeDefinition, TypeReference interfaceTypeReference) {
            TypeDefinition interfaceTypeDefinition;
            try {
                interfaceTypeDefinition = interfaceTypeReference.Resolve();
            }
            catch (Exception) {
                return false;
            }
            return Implements(typeDefinition, interfaceTypeDefinition);
        }

        public static bool Implements(this TypeDefinition typeDefinition, TypeDefinition interfaceTypeDefinition) {
            while (typeDefinition != null && typeDefinition.BaseType != null) {
                if (typeDefinition.Interfaces != null && typeDefinition.Interfaces
                        .Any(i => (i.FullName == interfaceTypeDefinition.FullName)
                            && typeDefinition.GenericParameters.Count == interfaceTypeDefinition.GenericParameters.Count
                            && typeDefinition.GenericParameters.Intersect(interfaceTypeDefinition.GenericParameters).Count() == typeDefinition.GenericParameters.Count)
                    )
                    return true;

                typeDefinition = typeDefinition.BaseType.Resolve();
            }

            return false;
        }

        public static bool DerivesFrom(this TypeReference typeReference, TypeReference expectedBaseTypeReference) {
            return DerivesFrom(typeReference.Resolve(), expectedBaseTypeReference.Resolve());
        }

        public static bool DerivesFrom(this TypeDefinition typeDefinition, TypeDefinition expectedBaseTypeDefinition) {
            while (typeDefinition != null) {
                if (typeDefinition.FullName.Equals(expectedBaseTypeDefinition.FullName)
                && typeDefinition.GenericParameters.Count == expectedBaseTypeDefinition.GenericParameters.Count
                && typeDefinition.GenericParameters.Intersect(expectedBaseTypeDefinition.GenericParameters).Count() == typeDefinition.GenericParameters.Count)
                    return true;

                typeDefinition = typeDefinition.Resolve().BaseType?.Resolve();
            }

            return false;
        }
    }
}