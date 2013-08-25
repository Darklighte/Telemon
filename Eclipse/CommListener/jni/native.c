#include <jni.h>
#include <string.h>
#include <android/log.h>

#define DEBUG_TAG "TestLibMain"


void Java_com_rucks_testlib_TestLibMain_printLog(JNIEnv * env, jobject this, jstring logString)
{
    jboolean isCopy;
    const char * szLogString = (*env)->GetStringUTFChars(env, logString, &isCopy);

    __android_log_print(ANDROID_LOG_DEBUG, DEBUG_TAG, "NDK: %s", szLogString);

    (*env)->ReleaseStringUTFChars(env, logString, szLogString);
}

jint Java_com_rucks_testlib_TestLibMain_fibonacci(JNIEnv * env, jobject this, jint value)
{
    if (value <= 1) return value;
    return Java_com_rucks_testlib_TestLibMain_fibonacci(env, this, value-1)
            + Java_com_rucks_testlib_TestLibMain_fibonacci(env, this, value-2);
}
