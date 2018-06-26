using System;

namespace QFramework
{
    public class Profiler : IDisposable{
        private long startTime;
        private string name;

        public Profiler(string name) {
            this.name = name;
            startTime = GetMilSec();
        }

        private long GetMilSec() {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }

        public void Dispose() {
            UnityEngine.Debug.LogFormat("Profiler {0} Time {1}", this.name, GetMilSec() - startTime);
        }
    }
}
