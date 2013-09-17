LOCAL_PATH 		:= $(call my-dir)
 
include $(CLEAR_VARS)

# override strip command to strip all symbols from output library; no need to ship with those..
# cmd-strip = $(TOOLCHAIN_PREFIX)strip $1
  
LOCAL_LDLIBS 	:= -llog
#LOCAL_CFLAGS    := -Werror 
LOCAL_ARM_MODE  := arm 
LOCAL_MODULE    := javabridge
LOCAL_SRC_FILES := javabridge.cpp
 
include $(BUILD_SHARED_LIBRARY)  