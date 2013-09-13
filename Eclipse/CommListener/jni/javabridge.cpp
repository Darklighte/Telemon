#include <stdlib.h>
#include <jni.h>
#include <android/log.h>
typedef unsigned int uint;
extern "C"
{

	JavaVM*		java_vm;

	jobject JNICALL FindMainActivity();

	JNIEXPORT jint JNICALL JNI_OnLoad(JavaVM* vm, void* reserved)
	{
		// use __android_log_print for logcat debugging.
		//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Creating java link vm = %08x\n", __FUNCTION__, (uint)vm);
		java_vm = vm;

		// attach our thread to the java vm; (it's already attached but this way we get the JNIEnv.)
		//JNIEnv* jni_env = 0;
		//java_vm->AttachCurrentThread(&jni_env, 0);
		//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] JNI Environment is = %08x\n", __FUNCTION__, (uint)jni_env);

		// find our main activity.
		//jclass cls_Activity		= jni_env->FindClass("com/unity3d/player/UnityPlayer");
		//jfieldID fid_Activity	= jni_env->GetStaticFieldID(cls_Activity, "currentActivity", "Landroid/app/Activity;");
		//jobject obj_Activity	= jni_env->GetStaticObjectField(cls_Activity, fid_Activity);
		//__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Current activity = %08x\n", __FUNCTION__, (uint)obj_Activity);

		//mainActivity = obj_Activity;
		//mainActivityClass = jni_env->GetObjectClass(mainActivityObj);

		//jclass testLibMainClass = jni_env->FindClass("com/rucks/testlib/TestLibMain");

		return JNI_VERSION_1_6;		// minimum JNI version
	}


	JNIEXPORT void JNICALL ToggleListenersNative(bool toggleSetting)
	{
		//reacquire environment
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);

		jobject mainActivityObj = FindMainActivity();
		jclass testLibMainClass = jni_env->FindClass("com/rucks/testlib/TestLibMain");

		if(toggleSetting)
		{
			jmethodID enableMethodID = jni_env->GetMethodID(testLibMainClass, "enableServiceListeners", "()V");
			/*if(enableMethodID != NULL)
			{
				__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s]Found enable method.", __FUNCTION__);
			}*/
			jni_env->CallVoidMethod(mainActivityObj, enableMethodID);
		}
		else
		{
			jmethodID disableMethodID = jni_env->GetMethodID(testLibMainClass, "disableServiceListeners", "()V");
			/*
			if(disableMethodID != NULL)
			{
				__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s]Found disable method.", __FUNCTION__);
			}
			*/
			jni_env->CallVoidMethod(mainActivityObj, disableMethodID);
		}
	}

	jobject JNICALL FindMainActivity()
	{
		// attach our thread to the java vm; (it's already attached but this way we get the JNIEnv.)
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);

		// find our main activity.
		jclass cls_Activity		= jni_env->FindClass("com/unity3d/player/UnityPlayer");
		jfieldID fid_Activity	= jni_env->GetStaticFieldID(cls_Activity, "currentActivity", "Landroid/app/Activity;");
		return jni_env->GetStaticObjectField(cls_Activity, fid_Activity);
	}
}
