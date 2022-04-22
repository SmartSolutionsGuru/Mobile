package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("SmartSolutions.Mobile.Droid.Application, SmartSolutions.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc649fac08c1dbe52fc2.Application.class, crc649fac08c1dbe52fc2.Application.__md_methods);
		mono.android.Runtime.register ("Caliburn.Micro.CaliburnApplication, Caliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f", crc648c15711fce523d6b.CaliburnApplication.class, crc648c15711fce523d6b.CaliburnApplication.__md_methods);
		
	}
}
