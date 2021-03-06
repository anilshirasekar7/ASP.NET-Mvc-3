﻿namespace Microsoft.Web.Mvc.ModelBinding {
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    // Returns a binder that can bind ComplexModelDto objects.
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dto")]
    public sealed class ComplexModelDtoModelBinderProvider : ModelBinderProvider {

        // This is really just a simple binder.
        private static readonly SimpleModelBinderProvider _underlyingProvider = GetUnderlyingProvider();

        public override IExtensibleModelBinder GetBinder(ControllerContext controllerContext, ExtensibleModelBindingContext bindingContext) {
            return _underlyingProvider.GetBinder(controllerContext, bindingContext);
        }

        private static SimpleModelBinderProvider GetUnderlyingProvider() {
            return new SimpleModelBinderProvider(typeof(ComplexModelDto), new ComplexModelDtoModelBinder()) {
                SuppressPrefixCheck = true
            };
        }

    }
}
