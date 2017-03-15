using Oxide.Core.Extensions;
using Oxide.Core;

namespace Oxide.Ext.FileIO
{
    public class PutRequestExtension : Extension
    {
        public override string Name => "PutRequest";
        public override VersionNumber Version => new VersionNumber(1, 0, 0);
        public override string Author => "PsychoTea";

        public PutRequestExtension(ExtensionManager manager) : base(manager)
        {
        }

        private Core.Libraries.PutRequest putRequest;
        public override void Load() => Manager.RegisterLibrary("PutRequest", putRequest = new Core.Libraries.PutRequest());
    }
}