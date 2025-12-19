using UnityEngine.Events;

namespace Architecture
{
    public class MonoController : SingletonMono<MonoController>
    {
        private event UnityAction updateEvent;

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if(updateEvent != null)
            {
                updateEvent();
            }
        }

        public void AddUpdateListener(UnityAction fun)
        {
            updateEvent += fun;
        }

        public void RemoveUpdateListener(UnityAction fun)
        {
            updateEvent -= fun;
        }
    }
}
