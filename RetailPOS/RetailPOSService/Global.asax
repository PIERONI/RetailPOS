<%@ Application Language="C#" %>
<%@ Import Namespace="Microsoft.Practices.Unity" %>
<%@ Import Namespace="RetailPOS.CommonLayer.Unity" %>
<%@ Import Namespace="RetailPOS.CommonLayer.UnityExtension" %>
<%@ Import Namespace="RetailPOS.CommonLayer.Mapper" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //Intialize the object factory to create the container for dependency injection
        RetailPOSUnityContainerExtension.InitializeContainer();

        //Resolve the Auto Mapper Contract to map the DTOs library with Data Objects
        RetailPOSUnityContainer.Container.Resolve<IObjectMapper>().CreateMap();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }  
</script>