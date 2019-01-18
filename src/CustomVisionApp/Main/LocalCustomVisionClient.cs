using CustomVisionApp.TensorFlow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVisionApp.Main
{
    public class LocalCustomVisionClient
    {
        private readonly TensorFlowEngine _engine = new TensorFlowEngine();

        public Task<string> AnalyzeAsync(byte[] image)
        {
            var result = _engine.Run(image);
            return Task.FromResult(result.Label);
        }
    }
}