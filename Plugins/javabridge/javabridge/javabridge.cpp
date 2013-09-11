#include <stdlib.h>
#include <jni.h>


extern "C"
{
	int blah = 0;

	JNIEXPORT int hereIAm()
	{
		return blah++;
	}












	//JavaVM*	java_vm;
	//jobject mainActivityObj;
	//jmethodID getSMSCount;

	//JNIEXPORT jint JNICALL JNI_OnLoad(JavaVM* vm, void* reserved)
	//{
	////	// use __android_log_print for logcat debugging.
	////	//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Creating java link vm = %08x\n", __FUNCTION__, vm);

	////	//save off VM pointer
	//	java_vm = vm;

	////	// attach our thread to the java vm; (it's already attached but this way we get the JNIEnv.)
	//	JNIEnv* jni_env = 0;
	//	java_vm->AttachCurrentThread((void**)&jni_env, 0);
	//	//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] JNI Environment is = %08x\n", __FUNCTION__, jni_env);

	////	// try to find our main activity.
	//	jclass cls_Activity		= jni_env->FindClass("com/unity3d/player/UnityPlayer");
	//	jfieldID fid_Activity	= jni_env->GetStaticFieldID(cls_Activity, "currentActivity", "Landroid/app/Activity;");
	//	mainActivityObj			= jni_env->GetStaticObjectField(cls_Activity, fid_Activity);
	////	//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Current activity = %08x\n", __FUNCTION__, obj_Activity);

	//	//getActivityCacheDir	= jni_env->GetMethodID(cls_JavaClass, "getActivityCacheDir", "()Ljava/lang/String;");
	//	jclass mainActivityClass = jni_env->GetObjectClass(mainActivityObj);
	//	getSMSCount = jni_env->GetMethodID(mainActivityClass, "getSMSCount", "()I");

	//	return JNI_VERSION_1_6;		// minimum JNI version
	//}

	//JNIEXPORT int getNewCount()
	//{
	//	int newCount = 0;

	////	//reacquire jni env.
	//	JNIEnv* jni_env = 0;
	//	java_vm->AttachCurrentThread((void**)&jni_env, 0);

	////	//call function?!?!?!?!
	//	jint jCount = (jint)jni_env->CallObjectMethod(mainActivityObj, getSMSCount);
	//	if(jCount != 0)
	//	{
	//		newCount = (int)jCount;
	//	}
	//	return newCount;
	//}
}
