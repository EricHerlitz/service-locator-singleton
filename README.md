# service-locator-singleton
I needed something simple but highly customizable and testable with the ability to initialize and bind class instances using annotations. I got inpsired by the way EPiServer constructed their ServiceLocator and how easy it is to register the types with class annotations. I wrapped it and used Microsoft Unity for the IoC.

Check the details of the project on my blog http://www.herlitz.nu/2015/10/21/servicelocator-singleton-pattern-with-annotation-mapping/

Usage of the included samples

    var a = ServiceLocator.Instance.Resolve<IServiceA>();
    a.Message = "Hello";
    
    var b = ServiceLocator.Instance.Resolve<IServiceB>();
    b.Number = 150;
    
    var c = ServiceLocator.Instance.Resolve<ClassA>();
    c.Check();

