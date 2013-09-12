#include <stdlib.h>
#include <jni.h>
#include <android/log.h>
typedef unsigned int uint;
extern "C"
{

	JavaVM*		java_vm;
	jobject		mainActivityObj;
	jclass 		mainActivityClass;
	jmethodID	getActivityCacheDir;



	JNIEXPORT jint JNICALL JNI_OnLoad(JavaVM* vm, void* reserved)
	{
		// use __android_log_print for logcat debugging.
		__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Creating java link vm = %08x\n", __FUNCTION__, (uint)vm);
		java_vm = vm;

		// attach our thread to the java vm; (it's already attached but this way we get the JNIEnv.)
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);
		__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] JNI Environment is = %08x\n", __FUNCTION__, (uint)jni_env);

		// find our main activity.
		jclass cls_Activity		= jni_env->FindClass("com/unity3d/player/UnityPlayer");
		jfieldID fid_Activity	= jni_env->GetStaticFieldID(cls_Activity, "currentActivity", "Landroid/app/Activity;");
		jobject obj_Activity	= jni_env->GetStaticObjectField(cls_Activity, fid_Activity);
		__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] Current activity = %08x\n", __FUNCTION__, (uint)obj_Activity);

		mainActivityObj = obj_Activity;
		mainActivityClass = jni_env->GetObjectClass(mainActivityObj);

		jclass testLibMainClass = jni_env->FindClass("com/rucks/testlib/TestLibMain");
		jclass activityClass = jni_env->FindClass("android/app/Activity");

		__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] testLibMain: %X, activityClass: %X, mainActivityClass: %X", __FUNCTION__, (uint)testLibMainClass, (uint) activityClass, (uint)mainActivityClass);

		if(mainActivityClass == jni_env->FindClass("com/rucks/testlib/TestLibMain"));
		{
			__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] It knows mainActivityClass is a TestLibMain", __FUNCTION__);
		}

		return JNI_VERSION_1_6;		// minimum JNI version
	}


	JNIEXPORT void JNICALL ToggleListenersNative(bool toggleSetting)
	{
		//reacquire environment
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);

		if(toggleSetting)
		{
			jmethodID enableMethodID = jni_env->GetMethodID(mainActivityClass, "enableServiceListeners", "()V");
			if(enableMethodID != NULL)
			{
				__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s]Found enable method.", __FUNCTION__);
			}
			jni_env->CallVoidMethod(mainActivityObj, enableMethodID);
		}
		else
		{
			jmethodID disableMethodID = jni_env->GetMethodID(mainActivityClass, "disableServiceListeners", "()V");
			if(disableMethodID != NULL)
			{
				__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s]Found disable method.", __FUNCTION__);
			}
			jni_env->CallVoidMethod(mainActivityObj, disableMethodID);
		}
	}

	/*
	JNIEXPORT void JNICALL SetNumber(int val)
	{
		//reacquire environment
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);

		jfieldID fidNumber = jni_env->GetFieldID(mainActivityClass, "canISetThis", "I");
		if(fidNumber == NULL)
		{
			__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] couldn't find canISetThis", __FUNCTION__);
			return;
		}

		jni_env->SetIntField(mainActivityObj, fidNumber, val);
	}

	JNIEXPORT int JNICALL GetNumber()
	{
		//reacquire environment
		JNIEnv* jni_env = 0;
		java_vm->AttachCurrentThread(&jni_env, 0);

		jfieldID fidNumber = jni_env->GetFieldID(mainActivityClass, "canISetThis", "I");
		if(fidNumber == NULL)
		{
			__android_log_print(ANDROID_LOG_INFO, "JavaBridge", "[%s] couldn't find canISetThis", __FUNCTION__);
			return 0;
		}

		return jni_env->GetIntField(mainActivityObj, fidNumber);

		return 0;
	}
	*/
}
