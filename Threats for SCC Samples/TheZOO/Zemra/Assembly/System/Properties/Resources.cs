namespace System.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    internal class Resources
    {
        private static CultureInfo cultureInfo_0;
        private static ResourceManager resourceManager_0;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo CultureInfo_0
        {
            get
            {
                return cultureInfo_0;
            }
            set
            {
                cultureInfo_0 = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager_0
        {
            get
            {
                if (object.ReferenceEquals(resourceManager_0, null))
                {
                    ResourceManager manager = new ResourceManager(<PrivateImplementationDetails>{15439A59-21B6-4268-85FC-B75D4C80FFCA}.smethod_11(), typeof(Resources).Assembly);
                    resourceManager_0 = manager;
                }
                return resourceManager_0;
            }
        }
    }
}

