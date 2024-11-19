using System;
using System.Collections.Generic;

namespace Services2{

    public static class ServiceLocator {
        private static Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void RegisterService<T>(T service) {
            var type = typeof(T);
            if (!services.ContainsKey(type)) {
                services[type] = service;
            }
        }

        public static T GetService<T>() {
            var type = typeof(T);
            if (services.ContainsKey(type)) {
                return (T)services[type];
            }
            throw new Exception("Service not found: " + type);
        }
    }
}
