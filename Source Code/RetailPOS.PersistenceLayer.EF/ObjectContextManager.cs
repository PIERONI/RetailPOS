using System.Collections;
using System.Data.Objects;
using System.Threading;
using System.Web;
using RetailPOS.PersistenceLayer.EF.EDMX;

namespace RetailPOS.PersistenceLayer.EF
{
    public static class ObjectContextManager
    {
        #region Private Members

        private const string OBJECT_CONTEXT_KEY = "RetailPOS.PersistenceLayer.EF.EDMX.POSEntities";
        
        // accessed via lock(_threadObjectContexts), only required for multi threaded non web applications
        private static readonly Hashtable _threadObjectContexts = new Hashtable();

        #endregion

        public static ObjectContext GetObjectContext()
        {
            ObjectContext objectContext = GetCurrentObjectContext(OBJECT_CONTEXT_KEY);

            if (objectContext == null)
            {
                // create and store the object context
                objectContext = HttpContext.Current.Session["ConnectionString"] == null ? new posEntities() : new posEntities(HttpContext.Current.Session["ConnectionString"].ToString());

                StoreCurrentObjectContext(objectContext, OBJECT_CONTEXT_KEY);
                objectContext.CommandTimeout = 120;
            }
            return objectContext;
        }

        /// <summary>
        /// gets the current object context 		
        /// </summary>
        private static ObjectContext GetCurrentObjectContext(string contextKey)
        {
            ObjectContext objectContext = null;
            
            if (HttpContext.Current == null)
            {
                objectContext = GetCurrentThreadObjectContext(contextKey);
            }
            else
            {
                objectContext = GetCurrentHttpContextObjectContext(contextKey);
            }
            return objectContext;
        }

        /// <summary>
        /// gets the object context for the current thread
        /// </summary>
        private static ObjectContext GetCurrentHttpContextObjectContext(string contextKey)
        {
            ObjectContext objectContext = null;
         
            if (HttpContext.Current.Items.Contains(contextKey))
            {
                objectContext = (ObjectContext)HttpContext.Current.Items[contextKey];
            }
            return objectContext;
        }

        /// <summary>
        /// gets the session for the current thread
        /// </summary>
        private static ObjectContext GetCurrentThreadObjectContext(string contextKey)
        {
            ObjectContext objectContext = null;
            Thread threadCurrent = Thread.CurrentThread;
            
            if (threadCurrent.Name == null)
            {
                threadCurrent.Name = contextKey;
            }
            else
            {
                object threadObjectContext = null;
                lock (_threadObjectContexts.SyncRoot)
                {
                    threadObjectContext = _threadObjectContexts[contextKey];
                }

                if (threadObjectContext != null)
                    objectContext = (ObjectContext)threadObjectContext;
            }
            return objectContext;
        }

        /// <summary>
        /// sets the current session 		
        /// </summary>
        private static void StoreCurrentObjectContext(ObjectContext objectContext, string contextKey)
        {
            if (HttpContext.Current == null)
            {
                StoreCurrentThreadObjectContext(objectContext, contextKey);
            }
            else
            {
                StoreCurrentHttpContextObjectContext(objectContext, contextKey);
            }
        }

        private static void StoreCurrentThreadObjectContext(ObjectContext objectContext, string contextKey)
        {
            lock (_threadObjectContexts.SyncRoot)
            {
                if (_threadObjectContexts.Contains(contextKey))
                {
                    _threadObjectContexts[contextKey] = objectContext;
                }
                else
                {
                    _threadObjectContexts.Add(contextKey, objectContext);
                }
            }
        }

        private static void StoreCurrentHttpContextObjectContext(ObjectContext objectContext, string contextKey)
        {
            if (HttpContext.Current.Items.Contains(contextKey))
            {
                HttpContext.Current.Items[contextKey] = objectContext;
            }
            else
            {
                HttpContext.Current.Items.Add(contextKey, objectContext);
            }
        }
    }
}