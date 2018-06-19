package md542d8f30b81adde2b11ac4d497a3a931d;


public class JsonGetter
	extends md542d8f30b81adde2b11ac4d497a3a931d.MainActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("QuickType.JsonGetter, QuickType", JsonGetter.class, __md_methods);
	}


	public JsonGetter ()
	{
		super ();
		if (getClass () == JsonGetter.class)
			mono.android.TypeManager.Activate ("QuickType.JsonGetter, QuickType", "", this, new java.lang.Object[] {  });
	}

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
