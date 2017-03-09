package md5a208241088659dceb54810e375091d95;


public class Splash
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RPGzinho.Droid.Splash, RPGzinho.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Splash.class, __md_methods);
	}


	public Splash () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Splash.class)
			mono.android.TypeManager.Activate ("RPGzinho.Droid.Splash, RPGzinho.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
