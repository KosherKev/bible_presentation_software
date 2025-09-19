-------------------------------------
Translated Report (Full Report Below)
-------------------------------------

Process:               BibleShow.UI [62288]
Path:                  /Users/USER/Documents/*/BibleShow.UI.app/Contents/MacOS/BibleShow.UI
Identifier:            com.companyname.bibleshow.ui
Version:               1.0 (1)
Code Type:             ARM-64 (Native)
Parent Process:        launchd [1]
User ID:               501

Date/Time:             2025-09-18 08:24:00.4423 +0000
OS Version:            macOS 15.6.1 (24G90)
Report Version:        12
Anonymous UUID:        6FEA9202-7DAE-917E-F1FF-5239B2E85F63

Sleep/Wake UUID:       A3B62DBA-9815-4E5F-957D-B2B783518547

Time Awake Since Boot: 43000 seconds
Time Since Wake:       1959 seconds

System Integrity Protection: enabled

Crashed Thread:        0  tid_103  Dispatch queue: com.apple.main-thread

Exception Type:        EXC_CRASH (SIGABRT)
Exception Codes:       0x0000000000000000, 0x0000000000000000

Termination Reason:    Namespace SIGNAL, Code 6 Abort trap: 6
Terminating Process:   BibleShow.UI [62288]

Application Specific Information:
abort() called


Thread 0 Crashed:: tid_103 Dispatch queue: com.apple.main-thread
0   libsystem_kernel.dylib        	       0x196cf6388 __pthread_kill + 8
1   libsystem_pthread.dylib       	       0x196d2f88c pthread_kill + 296
2   libsystem_c.dylib             	       0x196c38a3c abort + 124
3   BibleShow.UI                  	       0x1012c4b74 sigabrt_signal_handler.cold.1 + 48 (mini-posix.c:248)
4   BibleShow.UI                  	       0x1011df284 sigabrt_signal_handler + 196 (mini-posix.c:246)
5   libsystem_platform.dylib      	       0x196d696a4 _sigtramp + 56
6   libsystem_pthread.dylib       	       0x196d2f88c pthread_kill + 296
7   libsystem_c.dylib             	       0x196c38a3c abort + 124
8   libc++abi.dylib               	       0x196ce5384 abort_message + 132
9   libc++abi.dylib               	       0x196cd3cf4 demangling_terminate_handler() + 344
10  libobjc.A.dylib               	       0x196958dd4 _objc_terminate() + 156
11  libc++abi.dylib               	       0x196ce4698 std::__terminate(void (*)()) + 16
12  libc++abi.dylib               	       0x196ce7c30 __cxxabiv1::failed_throw(__cxxabiv1::__cxa_exception*) + 88
13  libc++abi.dylib               	       0x196ce7bd8 __cxa_throw + 92
14  libobjc.A.dylib               	       0x19694ecf8 objc_exception_throw + 448
15  BibleShow.UI                  	       0x100e39b74 xamarin_process_managed_exception + 1024 (runtime.m:2473)
16  BibleShow.UI                  	       0x100e470c0 xamarin_invoke_trampoline + 7576 (trampolines-invoke.m:785)
17  BibleShow.UI                  	       0x100e4ca78 xamarin_arch_trampoline + 148 (trampolines-arm64.m:316)
18  BibleShow.UI                  	       0x100e4d85c xamarin_arm64_common_trampoline + 64 (trampolines-arm64-asm.s:51)
19  UIKitCore                     	       0x1ca536ac4 -[UIApplication _handleDelegateCallbacksWithOptions:isSuspended:restoreState:] + 196
20  UIKitCore                     	       0x1ca535ff4 -[UIApplication _callInitializationDelegatesWithActions:forCanvas:payload:fromOriginatingProcess:] + 2960
21  UIKitCore                     	       0x1ca5342e0 -[UIApplication _runWithMainScene:transitionContext:completion:] + 1092
22  UIKitCore                     	       0x1ca533dac -[_UISceneLifecycleMultiplexer completeApplicationLaunchWithFBSScene:transitionContext:] + 108
23  UIKitCore                     	       0x1ca530824 _UIScenePerformActionsWithLifecycleActionMask + 112
24  UIKitCore                     	       0x1ca5336a4 __101-[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:]_block_invoke + 252
25  UIKitCore                     	       0x1ca53340c -[_UISceneLifecycleMultiplexer _performBlock:withApplicationOfDeactivationReasons:fromReasons:] + 316
26  UIKitCore                     	       0x1ca532968 -[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:] + 612
27  UIKitCore                     	       0x1ca532660 -[_UISceneLifecycleMultiplexer uiScene:transitionedFromState:withTransitionContext:] + 244
28  UIKitCore                     	       0x1ca530e00 __186-[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:]_block_invoke + 148
29  UIKitCore                     	       0x1cb027ec4 +[BSAnimationSettings(UIKit) tryAnimatingWithSettings:fromCurrentState:actions:completion:] + 736
30  UIKitCore                     	       0x1cb12cee4 _UISceneSettingsDiffActionPerformChangesWithTransitionContextAndCompletion + 224
31  UIKitCore                     	       0x1ca5309ac -[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:] + 316
32  UIKitCore                     	       0x1caa43fec __64-[UIScene scene:didUpdateWithDiff:transitionContext:completion:]_block_invoke.246 + 616
33  UIKitCore                     	       0x1ca52fe44 -[UIScene _emitSceneSettingsUpdateResponseForCompletion:afterSceneUpdateWork:] + 208
34  UIKitCore                     	       0x1ca52fcbc -[UIScene scene:didUpdateWithDiff:transitionContext:completion:] + 244
35  UIKitCore                     	       0x1ca5256d4 -[UIApplication workspace:didCreateScene:withTransitionContext:completion:] + 464
36  UIKitCore                     	       0x1ca52548c -[UIApplicationSceneClientAgent scene:didInitializeWithEvent:completion:] + 288
37  FrontBoardServices            	       0x1ae7661c8 __95-[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:]_block_invoke + 288
38  FrontBoardServices            	       0x1ae7666c4 -[FBSScene _callOutQueue_coalesceClientSettingsUpdates:] + 72
39  FrontBoardServices            	       0x1ae766014 -[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:] + 504
40  FrontBoardServices            	       0x1ae78ce90 __93-[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:]_block_invoke.234 + 296
41  FrontBoardServices            	       0x1ae74d2a8 -[FBSWorkspace _calloutQueue_executeCalloutFromSource:withBlock:] + 192
42  FrontBoardServices            	       0x1ae78b1fc -[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:] + 516
43  libdispatch.dylib             	       0x196b9185c _dispatch_client_callout + 16
44  libdispatch.dylib             	       0x196b7cb30 _dispatch_block_invoke_direct + 284
45  FrontBoardServices            	       0x1ae74d1c0 __FBSSERIALQUEUE_IS_CALLING_OUT_TO_A_BLOCK__ + 48
46  FrontBoardServices            	       0x1ae7a6898 -[FBSMainRunLoopSerialQueue _targetQueue_performNextIfPossible] + 240
47  FrontBoardServices            	       0x1ae7d472c -[FBSMainRunLoopSerialQueue _performNextFromRunLoopSource] + 28
48  CoreFoundation                	       0x196e1ab14 __CFRUNLOOP_IS_CALLING_OUT_TO_A_SOURCE0_PERFORM_FUNCTION__ + 28
49  CoreFoundation                	       0x196e1aaa8 __CFRunLoopDoSource0 + 172
50  CoreFoundation                	       0x196e1a814 __CFRunLoopDoSources0 + 232
51  CoreFoundation                	       0x196e19468 __CFRunLoopRun + 840
52  CoreFoundation                	       0x196e18a98 CFRunLoopRunSpecific + 572
53  HIToolbox                     	       0x1a28bb27c RunCurrentEventLoopInMode + 324
54  HIToolbox                     	       0x1a28be31c ReceiveNextEventCommon + 216
55  HIToolbox                     	       0x1a2a49484 _BlockUntilNextEventMatchingListInModeWithFilter + 76
56  AppKit                        	       0x19ad3da34 _DPSNextEvent + 684
57  AppKit                        	       0x19b6dc940 -[NSApplication(NSEventRouting) _nextEventMatchingEventMask:untilDate:inMode:dequeue:] + 688
58  AppKit                        	       0x19ad30be4 -[NSApplication run] + 480
59  AppKit                        	       0x19ad072dc NSApplicationMain + 880
60  AppKit                        	       0x19af53c84 _NSApplicationMainWithInfoDictionary + 24
61  UIKitMacHelper                	       0x1b2351164 UINSApplicationMain + 976
62  UIKitCore                     	       0x1ca50fc9c UIApplicationMain + 148
63  BibleShow.UI                  	       0x100e245f4 xamarin_UIApplicationMain + 60 (bindings.m:126)
64  BibleShow.UI                  	       0x1011efa18 do_icall + 316 (interp.c:2310)
65  BibleShow.UI                  	       0x1011edfb8 do_icall_wrapper + 356 (interp.c:2350)
66  BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
67  BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
68  BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
69  BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
70  BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
71  BibleShow.UI                  	       0x1010d5d40 do_exec_main_checked + 60 [inlined]
72  BibleShow.UI                  	       0x1010d5d40 mono_runtime_exec_main_checked + 116 (object.c:4775)
73  BibleShow.UI                  	       0x10117f570 mono_jit_exec_internal + 16 (driver.c:1369) [inlined]
74  BibleShow.UI                  	       0x10117f570 mono_jit_exec + 364 (driver.c:1314)
75  BibleShow.UI                  	       0x100e4c924 xamarin_main + 884 (monotouch-main.m:495)
76  BibleShow.UI                  	       0x1012c46b8 main + 64 (main.arm64.mm:86)
77  dyld                          	       0x19698eb98 start + 6076

Thread 1::  Dispatch queue: com.apple.root.default-qos
0   libsystem_kernel.dylib        	       0x196cef9b8 __ulock_wait + 8
1   libdispatch.dylib             	       0x196b79cbc _dlock_wait + 56
2   libdispatch.dylib             	       0x196b79adc _dispatch_thread_event_wait_slow + 56
3   libdispatch.dylib             	       0x196b87a88 __DISPATCH_WAIT_FOR_QUEUE__ + 368
4   libdispatch.dylib             	       0x196b87640 _dispatch_sync_f_slow + 148
5   AXCoreUtilities               	       0x1b956c5bc AXPerformBlockSynchronouslyOnMainThread + 80
6   libdispatch.dylib             	       0x196b77b2c _dispatch_call_block_and_release + 32
7   libdispatch.dylib             	       0x196b9185c _dispatch_client_callout + 16
8   libdispatch.dylib             	       0x196bad868 _dispatch_queue_override_invoke.cold.3 + 32
9   libdispatch.dylib             	       0x196b7c278 _dispatch_queue_override_invoke + 848
10  libdispatch.dylib             	       0x196b89e30 _dispatch_root_queue_drain + 364
11  libdispatch.dylib             	       0x196b8a5d4 _dispatch_worker_thread2 + 156
12  libsystem_pthread.dylib       	       0x196d2be28 _pthread_wqthread + 232
13  libsystem_pthread.dylib       	       0x196d2ab74 start_wqthread + 8

Thread 2::  Dispatch queue: com.apple.libtrace.state.block-list
0   libsystem_kernel.dylib        	       0x196cef9b8 __ulock_wait + 8
1   libdispatch.dylib             	       0x196b79cbc _dlock_wait + 56
2   libdispatch.dylib             	       0x196b79adc _dispatch_thread_event_wait_slow + 56
3   libdispatch.dylib             	       0x196b87a88 __DISPATCH_WAIT_FOR_QUEUE__ + 368
4   libdispatch.dylib             	       0x196b87640 _dispatch_sync_f_slow + 148
5   libsystem_trace.dylib         	       0x196a7e7a8 ___os_state_request_for_self_block_invoke + 372
6   libdispatch.dylib             	       0x196b77b2c _dispatch_call_block_and_release + 32
7   libdispatch.dylib             	       0x196b9185c _dispatch_client_callout + 16
8   libdispatch.dylib             	       0x196b80350 _dispatch_lane_serial_drain + 740
9   libdispatch.dylib             	       0x196b80e60 _dispatch_lane_invoke + 440
10  libdispatch.dylib             	       0x196b8b264 _dispatch_root_queue_drain_deferred_wlh + 292
11  libdispatch.dylib             	       0x196b8aae8 _dispatch_workloop_worker_thread + 540
12  libsystem_pthread.dylib       	       0x196d2be64 _pthread_wqthread + 292
13  libsystem_pthread.dylib       	       0x196d2ab74 start_wqthread + 8

Thread 3:: SGen worker
0   libsystem_kernel.dylib        	       0x196cf13cc __psynch_cvwait + 8
1   libsystem_pthread.dylib       	       0x196d300e0 _pthread_cond_wait + 984
2   BibleShow.UI                  	       0x101068a98 mono_os_cond_wait + 8 (mono-os-mutex.h:219) [inlined]
3   BibleShow.UI                  	       0x101068a98 get_work + 204 (sgen-thread-pool.c:164) [inlined]
4   BibleShow.UI                  	       0x101068a98 thread_func + 412 (sgen-thread-pool.c:195)
5   libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
6   libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 4:: Finalizer
0   libsystem_kernel.dylib        	       0x196cedbb0 semaphore_wait_trap + 8
1   BibleShow.UI                  	       0x101107424 mono_os_sem_wait + 12 (mono-os-semaphore.h:85) [inlined]
2   BibleShow.UI                  	       0x101107424 mono_coop_sem_wait + 44 (mono-coop-semaphore.h:41) [inlined]
3   BibleShow.UI                  	       0x101107424 finalizer_thread + 340 (gc.c:891)
4   BibleShow.UI                  	       0x1010e4504 start_wrapper_internal + 280 (threads.c:1202) [inlined]
5   BibleShow.UI                  	       0x1010e4504 start_wrapper + 348 (threads.c:1271)
6   libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
7   libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 5:
0   libsystem_pthread.dylib       	       0x196d2ab6c start_wqthread + 0

Thread 6:
0   libsystem_pthread.dylib       	       0x196d2ab6c start_wqthread + 0

Thread 7:: com.apple.uikit.eventfetch-thread
0   libsystem_kernel.dylib        	       0x196cedc34 mach_msg2_trap + 8
1   libsystem_kernel.dylib        	       0x196d003a0 mach_msg2_internal + 76
2   libsystem_kernel.dylib        	       0x196cf6764 mach_msg_overwrite + 484
3   libsystem_kernel.dylib        	       0x196cedfa8 mach_msg + 24
4   CoreFoundation                	       0x196e1acbc __CFRunLoopServiceMachPort + 160
5   CoreFoundation                	       0x196e195d8 __CFRunLoopRun + 1208
6   CoreFoundation                	       0x196e18a98 CFRunLoopRunSpecific + 572
7   Foundation                    	       0x1983e8c78 -[NSRunLoop(NSRunLoop) runMode:beforeDate:] + 212
8   Foundation                    	       0x19845c3a4 -[NSRunLoop(NSRunLoop) runUntilDate:] + 100
9   UIKitCore                     	       0x1ca511070 -[UIEventFetcher threadMain] + 104
10  Foundation                    	       0x1983e2ba8 __NSThread__start__ + 732
11  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
12  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 8:
0   libsystem_pthread.dylib       	       0x196d2ab6c start_wqthread + 0

Thread 9:
0   libsystem_pthread.dylib       	       0x196d2ab6c start_wqthread + 0

Thread 10:
0   libsystem_pthread.dylib       	       0x196d2ab6c start_wqthread + 0

Thread 11:: com.apple.NSEventThread
0   libsystem_kernel.dylib        	       0x196cedc34 mach_msg2_trap + 8
1   libsystem_kernel.dylib        	       0x196d003a0 mach_msg2_internal + 76
2   libsystem_kernel.dylib        	       0x196cf6764 mach_msg_overwrite + 484
3   libsystem_kernel.dylib        	       0x196cedfa8 mach_msg + 24
4   CoreFoundation                	       0x196e1acbc __CFRunLoopServiceMachPort + 160
5   CoreFoundation                	       0x196e195d8 __CFRunLoopRun + 1208
6   CoreFoundation                	       0x196e18a98 CFRunLoopRunSpecific + 572
7   AppKit                        	       0x19ae6178c _NSEventThread + 140
8   libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
9   libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 12:: .NET File Watcher
0   libsystem_kernel.dylib        	       0x196cedc34 mach_msg2_trap + 8
1   libsystem_kernel.dylib        	       0x196d003a0 mach_msg2_internal + 76
2   libsystem_kernel.dylib        	       0x196cf6764 mach_msg_overwrite + 484
3   libsystem_kernel.dylib        	       0x196cedfa8 mach_msg + 24
4   CoreFoundation                	       0x196e1acbc __CFRunLoopServiceMachPort + 160
5   CoreFoundation                	       0x196e195d8 __CFRunLoopRun + 1208
6   CoreFoundation                	       0x196e18a98 CFRunLoopRunSpecific + 572
7   CoreFoundation                	       0x196e92554 CFRunLoopRun + 64
8   BibleShow.UI                  	       0x1011ef938 do_icall + 92 (interp.c:2244)
9   BibleShow.UI                  	       0x1011edfb8 do_icall_wrapper + 356 (interp.c:2350)
10  BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
11  BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
12  BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
13  BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
14  BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
15  BibleShow.UI                  	       0x1010e45f8 start_wrapper_internal + 524 (threads.c:1213) [inlined]
16  BibleShow.UI                  	       0x1010e45f8 start_wrapper + 592 (threads.c:1271)
17  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
18  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 13:: .NET Timer
0   libsystem_kernel.dylib        	       0x196cf13cc __psynch_cvwait + 8
1   libsystem_pthread.dylib       	       0x196d300e0 _pthread_cond_wait + 984
2   BibleShow.UI                  	       0x1011ef958 do_icall + 124 (interp.c:2256)
3   BibleShow.UI                  	       0x1011edfb8 do_icall_wrapper + 356 (interp.c:2350)
4   BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
5   BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
6   BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
7   BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
8   BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
9   BibleShow.UI                  	       0x1010e45f8 start_wrapper_internal + 524 (threads.c:1213) [inlined]
10  BibleShow.UI                  	       0x1010e45f8 start_wrapper + 592 (threads.c:1271)
11  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
12  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 14:: .NET TP Worker
0   libsystem_kernel.dylib        	       0x196cf13cc __psynch_cvwait + 8
1   libsystem_pthread.dylib       	       0x196d3010c _pthread_cond_wait + 1028
2   BibleShow.UI                  	       0x10101e16c mono_os_cond_timedwait + 96 (mono-os-mutex.c:44)
3   BibleShow.UI                  	       0x1010222fc mono_coop_cond_timedwait + 32 (mono-coop-mutex.h:103) [inlined]
4   BibleShow.UI                  	       0x1010222fc mono_lifo_semaphore_timed_wait + 268 (lifo-semaphore.c:56)
5   BibleShow.UI                  	       0x1011ef98c do_icall + 176 (interp.c:2274)
6   BibleShow.UI                  	       0x1011edff0 do_icall_wrapper + 412 (interp.c:2354)
7   BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
8   BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
9   BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
10  BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
11  BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
12  BibleShow.UI                  	       0x1010e45f8 start_wrapper_internal + 524 (threads.c:1213) [inlined]
13  BibleShow.UI                  	       0x1010e45f8 start_wrapper + 592 (threads.c:1271)
14  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
15  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 15:: .NET TP Gate
0   libsystem_kernel.dylib        	       0x196cf13cc __psynch_cvwait + 8
1   libsystem_pthread.dylib       	       0x196d3010c _pthread_cond_wait + 1028
2   BibleShow.UI                  	       0x100ea9414 SystemNative_LowLevelMonitor_TimedWait + 88 (pal_threading.c:177)
3   BibleShow.UI                  	       0x1011ef98c do_icall + 176 (interp.c:2274)
4   BibleShow.UI                  	       0x1011edfb8 do_icall_wrapper + 356 (interp.c:2350)
5   BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
6   BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
7   BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
8   BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
9   BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
10  BibleShow.UI                  	       0x1010e45f8 start_wrapper_internal + 524 (threads.c:1213) [inlined]
11  BibleShow.UI                  	       0x1010e45f8 start_wrapper + 592 (threads.c:1271)
12  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
13  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 16:: .NET TP Worker
0   libsystem_kernel.dylib        	       0x196cf13cc __psynch_cvwait + 8
1   libsystem_pthread.dylib       	       0x196d3010c _pthread_cond_wait + 1028
2   BibleShow.UI                  	       0x10101e16c mono_os_cond_timedwait + 96 (mono-os-mutex.c:44)
3   BibleShow.UI                  	       0x1010222fc mono_coop_cond_timedwait + 32 (mono-coop-mutex.h:103) [inlined]
4   BibleShow.UI                  	       0x1010222fc mono_lifo_semaphore_timed_wait + 268 (lifo-semaphore.c:56)
5   BibleShow.UI                  	       0x1011ef98c do_icall + 176 (interp.c:2274)
6   BibleShow.UI                  	       0x1011edff0 do_icall_wrapper + 412 (interp.c:2354)
7   BibleShow.UI                  	       0x1011e3598 mono_interp_exec_method + 2832
8   BibleShow.UI                  	       0x1011e11ac interp_runtime_invoke + 244 (interp.c:2109)
9   BibleShow.UI                  	       0x10112f4b8 mono_jit_runtime_invoke + 1320 (mini-runtime.c:3683)
10  BibleShow.UI                  	       0x1010cfe80 do_runtime_invoke + 60 (object.c:2576) [inlined]
11  BibleShow.UI                  	       0x1010cfe80 mono_runtime_invoke_checked + 148 (object.c:2792)
12  BibleShow.UI                  	       0x1010e45f8 start_wrapper_internal + 524 (threads.c:1213) [inlined]
13  BibleShow.UI                  	       0x1010e45f8 start_wrapper + 592 (threads.c:1271)
14  libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
15  libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8

Thread 17:: HIE: M_ aa2747e30da52f49 2025-09-18 08:24:00.427
0   libsystem_kernel.dylib        	       0x196cedc34 mach_msg2_trap + 8
1   libsystem_kernel.dylib        	       0x196d003a0 mach_msg2_internal + 76
2   libsystem_kernel.dylib        	       0x196d1d884 thread_suspend + 108
3   HIServices                    	       0x19dbaf504 SOME_OTHER_THREAD_SWALLOWED_AT_LEAST_ONE_EXCEPTION + 20
4   Foundation                    	       0x1983e2ba8 __NSThread__start__ + 732
5   libsystem_pthread.dylib       	       0x196d2fc0c _pthread_start + 136
6   libsystem_pthread.dylib       	       0x196d2ab80 thread_start + 8


Thread 0 crashed with ARM Thread State (64-bit):
    x0: 0x0000000000000000   x1: 0x0000000000000000   x2: 0x0000000000000000   x3: 0x0000000000000000
    x4: 0xffffffff9182e338   x5: 0x0000000000000018   x6: 0x000000016fbec790   x7: 0x000000016fbebe80
    x8: 0x1ed4a1daf46e0829   x9: 0x1ed4a1d8f0a228e9  x10: 0x00000000000003ff  x11: 0x000000016fbebf08
   x12: 0x0000000000000000  x13: 0x0000000100e07338  x14: 0x000000000000001c  x15: 0x0000000000000001
   x16: 0x0000000000000148  x17: 0x0000000205d19558  x18: 0x0000000000000000  x19: 0x0000000000000006
   x20: 0x0000000000000103  x21: 0x0000000204cc21a0  x22: 0x00000002026a8000  x23: 0x0000000000000000
   x24: 0x0000000000000001  x25: 0x0000000204fad000  x26: 0x00000002034c7000  x27: 0x000000002b870064
   x28: 0x0000000000000010   fp: 0x000000016fbec7a0   lr: 0x0000000196d2f88c
    sp: 0x000000016fbec780   pc: 0x0000000196cf6388 cpsr: 0x40001000
   far: 0x0000000000000000  esr: 0x56000080  Address size fault

Binary Images:
       0x10020c000 -        0x101477fff com.companyname.bibleshow.ui (1.0) <39fea836-ca8a-3221-807e-302a2ac4491a> /Users/USER/Documents/*/BibleShow.UI.app/Contents/MacOS/BibleShow.UI
       0x101e30000 -        0x101e37fff com.apple.AutomaticAssessmentConfiguration (1.0) <e4472d7d-c96b-366d-8cac-05161cedfc12> /System/Library/Frameworks/AutomaticAssessmentConfiguration.framework/Versions/A/AutomaticAssessmentConfiguration
       0x101ee8000 -        0x101ef3fff libobjc-trampolines.dylib (*) <a3faee04-0f8b-3428-9497-560c97eca6fb> /usr/lib/libobjc-trampolines.dylib
       0x11d9b8000 -        0x11e04bfff com.apple.AGXMetal13-3 (329.2) <b303b4e8-5f17-39b8-8505-326aaf870f39> /System/Library/Extensions/AGXMetal13_3.bundle/Contents/MacOS/AGXMetal13_3
       0x196ced000 -        0x196d28653 libsystem_kernel.dylib (*) <6e4a96ad-04b8-3e8a-b91d-087e62306246> /usr/lib/system/libsystem_kernel.dylib
       0x196d29000 -        0x196d35a47 libsystem_pthread.dylib (*) <d6494ba9-171e-39fc-b1aa-28ecf87975d1> /usr/lib/system/libsystem_pthread.dylib
       0x196bc0000 -        0x196c41243 libsystem_c.dylib (*) <dfea8794-80ce-37c3-8f6a-108aa1d0b1b0> /usr/lib/system/libsystem_c.dylib
       0x196d66000 -        0x196d6de0b libsystem_platform.dylib (*) <fd19a599-8750-31f9-924f-c2810c938371> /usr/lib/system/libsystem_platform.dylib
       0x196ccf000 -        0x196cecfff libc++abi.dylib (*) <776a4afb-71ee-32ab-b2ee-e6ff80818654> /usr/lib/libc++abi.dylib
       0x196934000 -        0x196987893 libobjc.A.dylib (*) <8ca52e4d-f699-3d14-8061-eea9d4366538> /usr/lib/libobjc.A.dylib
       0x1ca50c000 -        0x1cc2a13df com.apple.UIKitCore (1.0) <0afe2622-c672-3033-85cb-b9715072bd79> /System/iOSSupport/System/Library/PrivateFrameworks/UIKitCore.framework/Versions/A/UIKitCore
       0x1ae749000 -        0x1ae8153bf com.apple.FrontBoardServices (943.6.1) <ac6831d1-8a69-3ecc-a85c-5f6c0538a749> /System/Library/PrivateFrameworks/FrontBoardServices.framework/Versions/A/FrontBoardServices
       0x196b76000 -        0x196bbc75f libdispatch.dylib (*) <24ce0d89-4114-30c2-a81a-3db1f5931cff> /usr/lib/system/libdispatch.dylib
       0x196d9e000 -        0x1972dcfff com.apple.CoreFoundation (6.9) <8d45baee-6cc0-3b89-93fd-ea1c8e15c6d7> /System/Library/Frameworks/CoreFoundation.framework/Versions/A/CoreFoundation
       0x1a27f8000 -        0x1a2afefdf com.apple.HIToolbox (2.1.1) <1a037942-11e0-3fc8-aad2-20b11e7ae1a4> /System/Library/Frameworks/Carbon.framework/Versions/A/Frameworks/HIToolbox.framework/Versions/A/HIToolbox
       0x19ad03000 -        0x19c193e3f com.apple.AppKit (6.9) <860c164c-d04c-30ff-8c6f-e672b74caf11> /System/Library/Frameworks/AppKit.framework/Versions/C/AppKit
       0x1b234d000 -        0x1b246a0bf com.apple.UIKitMacHelper (1.0) <a6ad07bb-52c9-3512-a568-9a2f1a78a73e> /System/Library/PrivateFrameworks/UIKitMacHelper.framework/Versions/A/UIKitMacHelper
       0x196988000 -        0x196a23577 dyld (*) <3247e185-ced2-36ff-9e29-47a77c23e004> /usr/lib/dyld
               0x0 - 0xffffffffffffffff ??? (*) <00000000-0000-0000-0000-000000000000> ???
       0x1b956a000 -        0x1b962561f com.apple.accessibility.AXCoreUtilities (1.0) <6adcd8e5-3ab2-3c1c-970c-3eddee222eed> /System/Library/PrivateFrameworks/AXCoreUtilities.framework/Versions/A/AXCoreUtilities
       0x196a73000 -        0x196a8e7ff libsystem_trace.dylib (*) <ac8466b8-af1d-3895-876b-228151f0df1d> /usr/lib/system/libsystem_trace.dylib
       0x19db79000 -        0x19dbe539f com.apple.HIServices (1.22) <3c31e34f-3cfd-3469-b90d-23da674476b3> /System/Library/Frameworks/ApplicationServices.framework/Versions/A/Frameworks/HIServices.framework/Versions/A/HIServices
       0x19838f000 -        0x19917859f com.apple.Foundation (6.9) <b9a92060-f21e-3ecf-9ded-94a65c68a6f4> /System/Library/Frameworks/Foundation.framework/Versions/C/Foundation

External Modification Summary:
  Calls made by other processes targeting this process:
    task_for_pid: 0
    thread_create: 0
    thread_set_state: 0
  Calls made by this process:
    task_for_pid: 0
    thread_create: 0
    thread_set_state: 0
  Calls made by all processes on this machine:
    task_for_pid: 0
    thread_create: 0
    thread_set_state: 0

VM Region Summary:
ReadOnly portion of Libraries: Total=1.8G resident=0K(0%) swapped_out_or_unallocated=1.8G(100%)
Writable regions: Total=746.2M written=691K(0%) resident=691K(0%) swapped_out=0K(0%) unallocated=745.5M(100%)

                                VIRTUAL   REGION 
REGION TYPE                        SIZE    COUNT (non-coalesced) 
===========                     =======  ======= 
Activity Tracing                   256K        1 
ColorSync                          528K       27 
CoreAnimation                      512K       32 
CoreGraphics                        32K        2 
CoreServices                       208K        1 
Dispatch continuations            64.0M        1 
Foundation                          16K        1 
Kernel Alloc Once                   32K        1 
MALLOC                           620.4M       59 
MALLOC guard page                  288K       18 
MALLOC_SMALL                        16K        1 
STACK GUARD                       56.3M       18 
Stack                             24.3M       18 
VM_ALLOCATE                       36.4M       47 
__AUTH                            7229K      820 
__AUTH_CONST                      87.1M     1070 
__CTF                               824        1 
__DATA                            29.5M     1046 
__DATA_CONST                      29.9M     1080 
__DATA_DIRTY                      2855K      357 
__FONT_DATA                        2352        1 
__INFO_FILTER                         8        1 
__LINKEDIT                       626.9M        5 
__OBJC_RO                         61.4M        1 
__OBJC_RW                         2396K        1 
__TEXT                             1.2G     1104 
__TPRO_CONST                       128K        2 
mapped file                      290.0M      123 
page table in kernel               691K        1 
shared memory                      864K       13 
===========                     =======  ======= 
TOTAL                              3.1G     5853 



-----------
Full Report
-----------

{"app_name":"BibleShow.UI","timestamp":"2025-09-18 08:24:04.00 +0000","app_version":"1.0","slice_uuid":"39fea836-ca8a-3221-807e-302a2ac4491a","build_version":"1","platform":6,"bundleID":"com.companyname.bibleshow.ui","share_with_app_devs":0,"is_first_party":0,"bug_type":"309","os_version":"macOS 15.6.1 (24G90)","roots_installed":0,"name":"BibleShow.UI","incident_id":"826F1000-72EC-4695-BD20-860997776C3F"}
{
  "uptime" : 43000,
  "procRole" : "Foreground",
  "version" : 2,
  "userID" : 501,
  "deployVersion" : 210,
  "modelCode" : "MacBookPro17,1",
  "coalitionID" : 11414,
  "osVersion" : {
    "train" : "macOS 15.6.1",
    "build" : "24G90",
    "releaseType" : "User"
  },
  "captureTime" : "2025-09-18 08:24:00.4423 +0000",
  "codeSigningMonitor" : 1,
  "incident" : "826F1000-72EC-4695-BD20-860997776C3F",
  "pid" : 62288,
  "translated" : false,
  "cpuType" : "ARM-64",
  "roots_installed" : 0,
  "bug_type" : "309",
  "procLaunch" : "2025-09-18 08:23:58.0022 +0000",
  "procStartAbsTime" : 1040443128872,
  "procExitAbsTime" : 1040501595883,
  "procName" : "BibleShow.UI",
  "procPath" : "\/Users\/USER\/Documents\/*\/BibleShow.UI.app\/Contents\/MacOS\/BibleShow.UI",
  "bundleInfo" : {"CFBundleShortVersionString":"1.0","CFBundleVersion":"1","CFBundleIdentifier":"com.companyname.bibleshow.ui"},
  "storeInfo" : {"deviceIdentifierForVendor":"D6C76D8F-AC1A-5B12-B491-9BAD7920E508","thirdParty":true},
  "parentProc" : "launchd",
  "parentPid" : 1,
  "coalitionName" : "com.companyname.bibleshow.ui",
  "crashReporterKey" : "6FEA9202-7DAE-917E-F1FF-5239B2E85F63",
  "appleIntelligenceStatus" : {"state":"unavailable","reasons":["selectedLanguageDoesNotMatchSelectedSiriLanguage"]},
  "codeSigningID" : "com.companyname.bibleshow.ui",
  "codeSigningTeamID" : "",
  "codeSigningFlags" : 570425857,
  "codeSigningValidationCategory" : 10,
  "codeSigningTrustLevel" : 4294967295,
  "codeSigningAuxiliaryInfo" : 0,
  "instructionByteStream" : {"beforePC":"fyMD1f17v6n9AwCRm+D\/l78DAJH9e8Go\/w9f1sADX9YQKYDSARAA1A==","atPC":"AwEAVH8jA9X9e7+p\/QMAkZDg\/5e\/AwCR\/XvBqP8PX9bAA1\/WcAqA0g=="},
  "bootSessionUUID" : "E6A90C99-3697-4725-AD8F-84D317AEC082",
  "wakeTime" : 1959,
  "sleepWakeUUID" : "A3B62DBA-9815-4E5F-957D-B2B783518547",
  "sip" : "enabled",
  "exception" : {"codes":"0x0000000000000000, 0x0000000000000000","rawCodes":[0,0],"type":"EXC_CRASH","signal":"SIGABRT"},
  "termination" : {"flags":0,"code":6,"namespace":"SIGNAL","indicator":"Abort trap: 6","byProc":"BibleShow.UI","byPid":62288},
  "asi" : {"libsystem_c.dylib":["abort() called"]},
  "extMods" : {"caller":{"thread_create":0,"thread_set_state":0,"task_for_pid":0},"system":{"thread_create":0,"thread_set_state":0,"task_for_pid":0},"targeted":{"thread_create":0,"thread_set_state":0,"task_for_pid":0},"warnings":0},
  "lastExceptionBacktrace" : [{"imageOffset":973524,"symbol":"__exceptionPreprocess","symbolLocation":164,"imageIndex":13},{"imageOffset":109456,"symbol":"objc_exception_throw","symbolLocation":88,"imageIndex":9},{"imageOffset":12770164,"sourceLine":2479,"sourceFile":"runtime.m","symbol":"xamarin_process_managed_exception","imageIndex":0,"symbolLocation":1024},{"imageOffset":12824768,"sourceLine":785,"sourceFile":"trampolines-invoke.m","symbol":"xamarin_invoke_trampoline","imageIndex":0,"symbolLocation":7576},{"imageOffset":12847736,"sourceLine":318,"sourceFile":"trampolines-arm64.m","symbol":"xamarin_arch_trampoline","imageIndex":0,"symbolLocation":148},{"imageOffset":12851292,"sourceLine":55,"sourceFile":"trampolines-arm64-asm.s","symbol":"xamarin_arm64_common_trampoline","imageIndex":0,"symbolLocation":64},{"imageOffset":174788,"symbol":"-[UIApplication _handleDelegateCallbacksWithOptions:isSuspended:restoreState:]","symbolLocation":196,"imageIndex":10},{"imageOffset":172020,"symbol":"-[UIApplication _callInitializationDelegatesWithActions:forCanvas:payload:fromOriginatingProcess:]","symbolLocation":2960,"imageIndex":10},{"imageOffset":164576,"symbol":"-[UIApplication _runWithMainScene:transitionContext:completion:]","symbolLocation":1092,"imageIndex":10},{"imageOffset":163244,"symbol":"-[_UISceneLifecycleMultiplexer completeApplicationLaunchWithFBSScene:transitionContext:]","symbolLocation":108,"imageIndex":10},{"imageOffset":149540,"symbol":"_UIScenePerformActionsWithLifecycleActionMask","symbolLocation":112,"imageIndex":10},{"imageOffset":161444,"symbol":"__101-[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:]_block_invoke","symbolLocation":252,"imageIndex":10},{"imageOffset":160780,"symbol":"-[_UISceneLifecycleMultiplexer _performBlock:withApplicationOfDeactivationReasons:fromReasons:]","symbolLocation":316,"imageIndex":10},{"imageOffset":158056,"symbol":"-[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:]","symbolLocation":612,"imageIndex":10},{"imageOffset":157280,"symbol":"-[_UISceneLifecycleMultiplexer uiScene:transitionedFromState:withTransitionContext:]","symbolLocation":244,"imageIndex":10},{"imageOffset":151040,"symbol":"__186-[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:]_block_invoke","symbolLocation":148,"imageIndex":10},{"imageOffset":11648708,"symbol":"+[BSAnimationSettings(UIKit) tryAnimatingWithSettings:fromCurrentState:actions:completion:]","symbolLocation":736,"imageIndex":10},{"imageOffset":12717796,"symbol":"_UISceneSettingsDiffActionPerformChangesWithTransitionContextAndCompletion","symbolLocation":224,"imageIndex":10},{"imageOffset":149932,"symbol":"-[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:]","symbolLocation":316,"imageIndex":10},{"imageOffset":5472236,"symbol":"__64-[UIScene scene:didUpdateWithDiff:transitionContext:completion:]_block_invoke.246","symbolLocation":616,"imageIndex":10},{"imageOffset":147012,"symbol":"-[UIScene _emitSceneSettingsUpdateResponseForCompletion:afterSceneUpdateWork:]","symbolLocation":208,"imageIndex":10},{"imageOffset":146620,"symbol":"-[UIScene scene:didUpdateWithDiff:transitionContext:completion:]","symbolLocation":244,"imageIndex":10},{"imageOffset":104148,"symbol":"-[UIApplication workspace:didCreateScene:withTransitionContext:completion:]","symbolLocation":464,"imageIndex":10},{"imageOffset":103564,"symbol":"-[UIApplicationSceneClientAgent scene:didInitializeWithEvent:completion:]","symbolLocation":288,"imageIndex":10},{"imageOffset":119240,"symbol":"__95-[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:]_block_invoke","symbolLocation":288,"imageIndex":11},{"imageOffset":120516,"symbol":"-[FBSScene _callOutQueue_coalesceClientSettingsUpdates:]","symbolLocation":72,"imageIndex":11},{"imageOffset":118804,"symbol":"-[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:]","symbolLocation":504,"imageIndex":11},{"imageOffset":278160,"symbol":"__93-[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:]_block_invoke.234","symbolLocation":296,"imageIndex":11},{"imageOffset":17064,"symbol":"-[FBSWorkspace _calloutQueue_executeCalloutFromSource:withBlock:]","symbolLocation":192,"imageIndex":11},{"imageOffset":270844,"symbol":"-[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:]","symbolLocation":516,"imageIndex":11},{"imageOffset":112732,"symbol":"_dispatch_client_callout","symbolLocation":16,"imageIndex":12},{"imageOffset":27440,"symbol":"_dispatch_block_invoke_direct","symbolLocation":284,"imageIndex":12},{"imageOffset":16832,"symbol":"__FBSSERIALQUEUE_IS_CALLING_OUT_TO_A_BLOCK__","symbolLocation":48,"imageIndex":11},{"imageOffset":383128,"symbol":"-[FBSMainRunLoopSerialQueue _targetQueue_performNextIfPossible]","symbolLocation":240,"imageIndex":11},{"imageOffset":571180,"symbol":"-[FBSMainRunLoopSerialQueue _performNextFromRunLoopSource]","symbolLocation":28,"imageIndex":11},{"imageOffset":510740,"symbol":"__CFRUNLOOP_IS_CALLING_OUT_TO_A_SOURCE0_PERFORM_FUNCTION__","symbolLocation":28,"imageIndex":13},{"imageOffset":510632,"symbol":"__CFRunLoopDoSource0","symbolLocation":172,"imageIndex":13},{"imageOffset":509972,"symbol":"__CFRunLoopDoSources0","symbolLocation":232,"imageIndex":13},{"imageOffset":504936,"symbol":"__CFRunLoopRun","symbolLocation":840,"imageIndex":13},{"imageOffset":502424,"symbol":"CFRunLoopRunSpecific","symbolLocation":572,"imageIndex":13},{"imageOffset":799356,"symbol":"RunCurrentEventLoopInMode","symbolLocation":324,"imageIndex":14},{"imageOffset":811804,"symbol":"ReceiveNextEventCommon","symbolLocation":216,"imageIndex":14},{"imageOffset":2430084,"symbol":"_BlockUntilNextEventMatchingListInModeWithFilter","symbolLocation":76,"imageIndex":14},{"imageOffset":240180,"symbol":"_DPSNextEvent","symbolLocation":684,"imageIndex":15},{"imageOffset":10328384,"symbol":"-[NSApplication(NSEventRouting) _nextEventMatchingEventMask:untilDate:inMode:dequeue:]","symbolLocation":688,"imageIndex":15},{"imageOffset":187364,"symbol":"-[NSApplication run]","symbolLocation":480,"imageIndex":15},{"imageOffset":17116,"symbol":"NSApplicationMain","symbolLocation":880,"imageIndex":15},{"imageOffset":2428036,"symbol":"+[NSWindow _savedFrameFromString:]","symbolLocation":0,"imageIndex":15},{"imageOffset":16740,"symbol":"UINSApplicationMain","symbolLocation":976,"imageIndex":16},{"imageOffset":15516,"symbol":"UIApplicationMain","symbolLocation":148,"imageIndex":10},{"imageOffset":12682740,"sourceLine":126,"sourceFile":"bindings.m","symbol":"xamarin_UIApplicationMain","imageIndex":0,"symbolLocation":60},{"imageOffset":16661016,"sourceLine":2310,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":316},{"imageOffset":16654264,"sourceLine":2351,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":356},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2110,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3684,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"imageOffset":15506752,"sourceFile":"object.c","symbol":"do_exec_main_checked","imageIndex":0,"symbolLocation":60,"inline":true},{"imageOffset":15506752,"sourceLine":4775,"sourceFile":"object.c","symbol":"mono_runtime_exec_main_checked","imageIndex":0,"symbolLocation":116},{"symbol":"mono_jit_exec_internal","inline":true,"imageIndex":0,"imageOffset":16201072,"symbolLocation":16,"sourceLine":1369,"sourceFile":"driver.c"},{"imageOffset":16201072,"sourceLine":1314,"sourceFile":"driver.c","symbol":"mono_jit_exec","imageIndex":0,"symbolLocation":364},{"imageOffset":12847396,"sourceLine":495,"sourceFile":"monotouch-main.m","symbol":"xamarin_main","imageIndex":0,"symbolLocation":884},{"imageOffset":17532600,"sourceLine":86,"sourceFile":"main.arm64.mm","symbol":"main","imageIndex":0,"symbolLocation":64},{"imageOffset":27544,"symbol":"start","symbolLocation":6076,"imageIndex":17}],
  "faultingThread" : 0,
  "threads" : [{"threadState":{"x":[{"value":0},{"value":0},{"value":0},{"value":0},{"value":18446744071855858488},{"value":24},{"value":6169741200},{"value":6169738880},{"value":2221578477976291369},{"value":2221578469322664169},{"value":1023},{"value":6169739016},{"value":0},{"value":4309676856,"symbolLocation":0,"symbol":"jit_code_end"},{"value":28},{"value":1},{"value":328},{"value":8687555928},{"value":0},{"value":6},{"value":259},{"value":8670421408,"symbolLocation":224,"symbol":"_main_thread"},{"value":8630468608,"symbolLocation":0,"symbol":"OBJC_IVAR_$_Object.isa"},{"value":0},{"value":1},{"value":8673480704,"symbolLocation":0,"symbol":"OBJC_CLASS_$_UIInputViewAnimationStyle"},{"value":8645275648,"symbolLocation":0,"symbol":"OBJC_IVAR_$__UIDebugLogMessage._string"},{"value":730267748},{"value":16}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825375884},"cpsr":{"value":1073745920},"fp":{"value":6169741216},"sp":{"value":6169741184},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825141128,"matchesCrashFrame":1},"far":{"value":0}},"id":594921,"triggered":true,"name":"tid_103","queue":"com.apple.main-thread","frames":[{"imageOffset":37768,"symbol":"__pthread_kill","symbolLocation":8,"imageIndex":4},{"imageOffset":26764,"symbol":"pthread_kill","symbolLocation":296,"imageIndex":5},{"imageOffset":494140,"symbol":"abort","symbolLocation":124,"imageIndex":6},{"imageOffset":17533812,"sourceLine":248,"sourceFile":"mini-posix.c","symbol":"sigabrt_signal_handler.cold.1","imageIndex":0,"symbolLocation":48},{"imageOffset":16593540,"sourceLine":246,"sourceFile":"mini-posix.c","symbol":"sigabrt_signal_handler","imageIndex":0,"symbolLocation":196},{"imageOffset":13988,"symbol":"_sigtramp","symbolLocation":56,"imageIndex":7},{"imageOffset":26764,"symbol":"pthread_kill","symbolLocation":296,"imageIndex":5},{"imageOffset":494140,"symbol":"abort","symbolLocation":124,"imageIndex":6},{"imageOffset":91012,"symbol":"abort_message","symbolLocation":132,"imageIndex":8},{"imageOffset":19700,"symbol":"demangling_terminate_handler()","symbolLocation":344,"imageIndex":8},{"imageOffset":150996,"symbol":"_objc_terminate()","symbolLocation":156,"imageIndex":9},{"imageOffset":87704,"symbol":"std::__terminate(void (*)())","symbolLocation":16,"imageIndex":8},{"imageOffset":101424,"symbol":"__cxxabiv1::failed_throw(__cxxabiv1::__cxa_exception*)","symbolLocation":88,"imageIndex":8},{"imageOffset":101336,"symbol":"__cxa_throw","symbolLocation":92,"imageIndex":8},{"imageOffset":109816,"symbol":"objc_exception_throw","symbolLocation":448,"imageIndex":9},{"imageOffset":12770164,"sourceLine":2473,"sourceFile":"runtime.m","symbol":"xamarin_process_managed_exception","imageIndex":0,"symbolLocation":1024},{"imageOffset":12824768,"sourceLine":785,"sourceFile":"trampolines-invoke.m","symbol":"xamarin_invoke_trampoline","imageIndex":0,"symbolLocation":7576},{"imageOffset":12847736,"sourceLine":316,"sourceFile":"trampolines-arm64.m","symbol":"xamarin_arch_trampoline","imageIndex":0,"symbolLocation":148},{"imageOffset":12851292,"sourceLine":51,"sourceFile":"trampolines-arm64-asm.s","symbol":"xamarin_arm64_common_trampoline","imageIndex":0,"symbolLocation":64},{"imageOffset":174788,"symbol":"-[UIApplication _handleDelegateCallbacksWithOptions:isSuspended:restoreState:]","symbolLocation":196,"imageIndex":10},{"imageOffset":172020,"symbol":"-[UIApplication _callInitializationDelegatesWithActions:forCanvas:payload:fromOriginatingProcess:]","symbolLocation":2960,"imageIndex":10},{"imageOffset":164576,"symbol":"-[UIApplication _runWithMainScene:transitionContext:completion:]","symbolLocation":1092,"imageIndex":10},{"imageOffset":163244,"symbol":"-[_UISceneLifecycleMultiplexer completeApplicationLaunchWithFBSScene:transitionContext:]","symbolLocation":108,"imageIndex":10},{"imageOffset":149540,"symbol":"_UIScenePerformActionsWithLifecycleActionMask","symbolLocation":112,"imageIndex":10},{"imageOffset":161444,"symbol":"__101-[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:]_block_invoke","symbolLocation":252,"imageIndex":10},{"imageOffset":160780,"symbol":"-[_UISceneLifecycleMultiplexer _performBlock:withApplicationOfDeactivationReasons:fromReasons:]","symbolLocation":316,"imageIndex":10},{"imageOffset":158056,"symbol":"-[_UISceneLifecycleMultiplexer _evalTransitionToSettings:fromSettings:forceExit:withTransitionStore:]","symbolLocation":612,"imageIndex":10},{"imageOffset":157280,"symbol":"-[_UISceneLifecycleMultiplexer uiScene:transitionedFromState:withTransitionContext:]","symbolLocation":244,"imageIndex":10},{"imageOffset":151040,"symbol":"__186-[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:]_block_invoke","symbolLocation":148,"imageIndex":10},{"imageOffset":11648708,"symbol":"+[BSAnimationSettings(UIKit) tryAnimatingWithSettings:fromCurrentState:actions:completion:]","symbolLocation":736,"imageIndex":10},{"imageOffset":12717796,"symbol":"_UISceneSettingsDiffActionPerformChangesWithTransitionContextAndCompletion","symbolLocation":224,"imageIndex":10},{"imageOffset":149932,"symbol":"-[_UIWindowSceneFBSSceneTransitionContextDrivenLifecycleSettingsDiffAction _performActionsForUIScene:withUpdatedFBSScene:settingsDiff:fromSettings:transitionContext:lifecycleActionType:]","symbolLocation":316,"imageIndex":10},{"imageOffset":5472236,"symbol":"__64-[UIScene scene:didUpdateWithDiff:transitionContext:completion:]_block_invoke.246","symbolLocation":616,"imageIndex":10},{"imageOffset":147012,"symbol":"-[UIScene _emitSceneSettingsUpdateResponseForCompletion:afterSceneUpdateWork:]","symbolLocation":208,"imageIndex":10},{"imageOffset":146620,"symbol":"-[UIScene scene:didUpdateWithDiff:transitionContext:completion:]","symbolLocation":244,"imageIndex":10},{"imageOffset":104148,"symbol":"-[UIApplication workspace:didCreateScene:withTransitionContext:completion:]","symbolLocation":464,"imageIndex":10},{"imageOffset":103564,"symbol":"-[UIApplicationSceneClientAgent scene:didInitializeWithEvent:completion:]","symbolLocation":288,"imageIndex":10},{"imageOffset":119240,"symbol":"__95-[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:]_block_invoke","symbolLocation":288,"imageIndex":11},{"imageOffset":120516,"symbol":"-[FBSScene _callOutQueue_coalesceClientSettingsUpdates:]","symbolLocation":72,"imageIndex":11},{"imageOffset":118804,"symbol":"-[FBSScene _callOutQueue_didCreateWithTransitionContext:alternativeCreationCallout:completion:]","symbolLocation":504,"imageIndex":11},{"imageOffset":278160,"symbol":"__93-[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:]_block_invoke.234","symbolLocation":296,"imageIndex":11},{"imageOffset":17064,"symbol":"-[FBSWorkspace _calloutQueue_executeCalloutFromSource:withBlock:]","symbolLocation":192,"imageIndex":11},{"imageOffset":270844,"symbol":"-[FBSWorkspaceScenesClient _callOutQueue_sendDidCreateForScene:transitionContext:completion:]","symbolLocation":516,"imageIndex":11},{"imageOffset":112732,"symbol":"_dispatch_client_callout","symbolLocation":16,"imageIndex":12},{"imageOffset":27440,"symbol":"_dispatch_block_invoke_direct","symbolLocation":284,"imageIndex":12},{"imageOffset":16832,"symbol":"__FBSSERIALQUEUE_IS_CALLING_OUT_TO_A_BLOCK__","symbolLocation":48,"imageIndex":11},{"imageOffset":383128,"symbol":"-[FBSMainRunLoopSerialQueue _targetQueue_performNextIfPossible]","symbolLocation":240,"imageIndex":11},{"imageOffset":571180,"symbol":"-[FBSMainRunLoopSerialQueue _performNextFromRunLoopSource]","symbolLocation":28,"imageIndex":11},{"imageOffset":510740,"symbol":"__CFRUNLOOP_IS_CALLING_OUT_TO_A_SOURCE0_PERFORM_FUNCTION__","symbolLocation":28,"imageIndex":13},{"imageOffset":510632,"symbol":"__CFRunLoopDoSource0","symbolLocation":172,"imageIndex":13},{"imageOffset":509972,"symbol":"__CFRunLoopDoSources0","symbolLocation":232,"imageIndex":13},{"imageOffset":504936,"symbol":"__CFRunLoopRun","symbolLocation":840,"imageIndex":13},{"imageOffset":502424,"symbol":"CFRunLoopRunSpecific","symbolLocation":572,"imageIndex":13},{"imageOffset":799356,"symbol":"RunCurrentEventLoopInMode","symbolLocation":324,"imageIndex":14},{"imageOffset":811804,"symbol":"ReceiveNextEventCommon","symbolLocation":216,"imageIndex":14},{"imageOffset":2430084,"symbol":"_BlockUntilNextEventMatchingListInModeWithFilter","symbolLocation":76,"imageIndex":14},{"imageOffset":240180,"symbol":"_DPSNextEvent","symbolLocation":684,"imageIndex":15},{"imageOffset":10328384,"symbol":"-[NSApplication(NSEventRouting) _nextEventMatchingEventMask:untilDate:inMode:dequeue:]","symbolLocation":688,"imageIndex":15},{"imageOffset":187364,"symbol":"-[NSApplication run]","symbolLocation":480,"imageIndex":15},{"imageOffset":17116,"symbol":"NSApplicationMain","symbolLocation":880,"imageIndex":15},{"imageOffset":2428036,"symbol":"_NSApplicationMainWithInfoDictionary","symbolLocation":24,"imageIndex":15},{"imageOffset":16740,"symbol":"UINSApplicationMain","symbolLocation":976,"imageIndex":16},{"imageOffset":15516,"symbol":"UIApplicationMain","symbolLocation":148,"imageIndex":10},{"imageOffset":12682740,"sourceLine":126,"sourceFile":"bindings.m","symbol":"xamarin_UIApplicationMain","imageIndex":0,"symbolLocation":60},{"imageOffset":16661016,"sourceLine":2310,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":316},{"imageOffset":16654264,"sourceLine":2350,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":356},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"imageOffset":15506752,"sourceFile":"object.c","symbol":"do_exec_main_checked","imageIndex":0,"symbolLocation":60,"inline":true},{"imageOffset":15506752,"sourceLine":4775,"sourceFile":"object.c","symbol":"mono_runtime_exec_main_checked","imageIndex":0,"symbolLocation":116},{"symbol":"mono_jit_exec_internal","inline":true,"imageIndex":0,"imageOffset":16201072,"symbolLocation":16,"sourceLine":1369,"sourceFile":"driver.c"},{"imageOffset":16201072,"sourceLine":1314,"sourceFile":"driver.c","symbol":"mono_jit_exec","imageIndex":0,"symbolLocation":364},{"imageOffset":12847396,"sourceLine":495,"sourceFile":"monotouch-main.m","symbol":"xamarin_main","imageIndex":0,"symbolLocation":884},{"imageOffset":17532600,"sourceLine":86,"sourceFile":"main.arm64.mm","symbol":"main","imageIndex":0,"symbolLocation":64},{"imageOffset":27544,"symbol":"start","symbolLocation":6076,"imageIndex":17}]},{"id":595062,"threadState":{"x":[{"value":18446744073709551612},{"value":0},{"value":4294967295},{"value":0},{"value":8670436416,"symbolLocation":0,"symbol":"_dispatch_main_q"},{"value":18},{"value":0},{"value":0},{"value":0},{"value":4387259792},{"value":8670436520,"symbolLocation":104,"symbol":"_dispatch_main_q"},{"value":5},{"value":4387259782},{"value":8670436464,"symbolLocation":48,"symbol":"_dispatch_main_q"},{"value":0},{"value":4387259782},{"value":515},{"value":8687556088},{"value":0},{"value":4294967295},{"value":1},{"value":0},{"value":6170324464},{"value":6170325216},{"value":8670438208,"symbolLocation":1536,"symbol":"_dispatch_root_queues"},{"value":1535},{"value":8630527748,"symbolLocation":0,"symbol":"_dispatch_continuation_cache_limit"},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6823582908},"cpsr":{"value":1073745920},"fp":{"value":6170324272},"sp":{"value":6170324240},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825114040},"far":{"value":0}},"queue":"com.apple.root.default-qos","frames":[{"imageOffset":10680,"symbol":"__ulock_wait","symbolLocation":8,"imageIndex":4},{"imageOffset":15548,"symbol":"_dlock_wait","symbolLocation":56,"imageIndex":12},{"imageOffset":15068,"symbol":"_dispatch_thread_event_wait_slow","symbolLocation":56,"imageIndex":12},{"imageOffset":72328,"symbol":"__DISPATCH_WAIT_FOR_QUEUE__","symbolLocation":368,"imageIndex":12},{"imageOffset":71232,"symbol":"_dispatch_sync_f_slow","symbolLocation":148,"imageIndex":12},{"imageOffset":9660,"symbol":"AXPerformBlockSynchronouslyOnMainThread","symbolLocation":80,"imageIndex":19},{"imageOffset":6956,"symbol":"_dispatch_call_block_and_release","symbolLocation":32,"imageIndex":12},{"imageOffset":112732,"symbol":"_dispatch_client_callout","symbolLocation":16,"imageIndex":12},{"imageOffset":227432,"symbol":"_dispatch_queue_override_invoke.cold.3","symbolLocation":32,"imageIndex":12},{"imageOffset":25208,"symbol":"_dispatch_queue_override_invoke","symbolLocation":848,"imageIndex":12},{"imageOffset":81456,"symbol":"_dispatch_root_queue_drain","symbolLocation":364,"imageIndex":12},{"imageOffset":83412,"symbol":"_dispatch_worker_thread2","symbolLocation":156,"imageIndex":12},{"imageOffset":11816,"symbol":"_pthread_wqthread","symbolLocation":232,"imageIndex":5},{"imageOffset":7028,"symbol":"start_wqthread","symbolLocation":8,"imageIndex":5}]},{"id":595063,"threadState":{"x":[{"value":18446744073709551612},{"value":0},{"value":4294967295},{"value":0},{"value":8670436416,"symbolLocation":0,"symbol":"_dispatch_main_q"},{"value":18},{"value":0},{"value":0},{"value":0},{"value":4387275984},{"value":8670436520,"symbolLocation":104,"symbol":"_dispatch_main_q"},{"value":5},{"value":4387275974},{"value":8670436464,"symbolLocation":48,"symbol":"_dispatch_main_q"},{"value":0},{"value":4387275974},{"value":515},{"value":8687556088},{"value":0},{"value":4294967295},{"value":1},{"value":0},{"value":6170896208},{"value":6170896368},{"value":4772817504},{"value":6941020160},{"value":0},{"value":5323579448},{"value":9223372036856549652}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6823582908},"cpsr":{"value":1073745920},"fp":{"value":6170896016},"sp":{"value":6170895984},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825114040},"far":{"value":0}},"queue":"com.apple.libtrace.state.block-list","frames":[{"imageOffset":10680,"symbol":"__ulock_wait","symbolLocation":8,"imageIndex":4},{"imageOffset":15548,"symbol":"_dlock_wait","symbolLocation":56,"imageIndex":12},{"imageOffset":15068,"symbol":"_dispatch_thread_event_wait_slow","symbolLocation":56,"imageIndex":12},{"imageOffset":72328,"symbol":"__DISPATCH_WAIT_FOR_QUEUE__","symbolLocation":368,"imageIndex":12},{"imageOffset":71232,"symbol":"_dispatch_sync_f_slow","symbolLocation":148,"imageIndex":12},{"imageOffset":47016,"symbol":"___os_state_request_for_self_block_invoke","symbolLocation":372,"imageIndex":20},{"imageOffset":6956,"symbol":"_dispatch_call_block_and_release","symbolLocation":32,"imageIndex":12},{"imageOffset":112732,"symbol":"_dispatch_client_callout","symbolLocation":16,"imageIndex":12},{"imageOffset":41808,"symbol":"_dispatch_lane_serial_drain","symbolLocation":740,"imageIndex":12},{"imageOffset":44640,"symbol":"_dispatch_lane_invoke","symbolLocation":440,"imageIndex":12},{"imageOffset":86628,"symbol":"_dispatch_root_queue_drain_deferred_wlh","symbolLocation":292,"imageIndex":12},{"imageOffset":84712,"symbol":"_dispatch_workloop_worker_thread","symbolLocation":540,"imageIndex":12},{"imageOffset":11876,"symbol":"_pthread_wqthread","symbolLocation":292,"imageIndex":5},{"imageOffset":7028,"symbol":"start_wqthread","symbolLocation":8,"imageIndex":5}]},{"id":595083,"name":"SGen worker","threadState":{"x":[{"value":260},{"value":0},{"value":0},{"value":0},{"value":0},{"value":161},{"value":0},{"value":0},{"value":6171471560},{"value":0},{"value":0},{"value":2},{"value":2},{"value":0},{"value":0},{"value":0},{"value":305},{"value":8687555856},{"value":0},{"value":4317395776,"symbolLocation":136,"symbol":"_MergedGlobals"},{"value":4317395680,"symbolLocation":40,"symbol":"_MergedGlobals"},{"value":6171472096},{"value":0},{"value":0},{"value":0},{"value":1},{"value":256},{"value":0},{"value":4317392896,"symbolLocation":6912,"symbol":"pin_hash_filter"}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825378016},"cpsr":{"value":1610616832},"fp":{"value":6171471680},"sp":{"value":6171471536},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825120716},"far":{"value":0}},"frames":[{"imageOffset":17356,"symbol":"__psynch_cvwait","symbolLocation":8,"imageIndex":4},{"imageOffset":28896,"symbol":"_pthread_cond_wait","symbolLocation":984,"imageIndex":5},{"symbol":"mono_os_cond_wait","inline":true,"imageIndex":0,"imageOffset":15059608,"symbolLocation":8,"sourceLine":219,"sourceFile":"mono-os-mutex.h"},{"symbol":"get_work","inline":true,"imageIndex":0,"imageOffset":15059608,"symbolLocation":204,"sourceLine":164,"sourceFile":"sgen-thread-pool.c"},{"imageOffset":15059608,"sourceLine":195,"sourceFile":"sgen-thread-pool.c","symbol":"thread_func","imageIndex":0,"symbolLocation":412},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595087,"name":"Finalizer","threadState":{"x":[{"value":14},{"value":4315885453},{"value":18446744073709551608},{"value":5327324024},{"value":846293720},{"value":16},{"value":0},{"value":0},{"value":4317401088,"symbolLocation":120,"symbol":"_MergedGlobals"},{"value":6},{"value":5335375384},{"value":2},{"value":2},{"value":0},{"value":256},{"value":0},{"value":18446744073709551580},{"value":8687564456},{"value":0},{"value":1},{"value":4317402488,"symbolLocation":16,"symbol":"_MergedGlobals"},{"value":4317402536,"symbolLocation":64,"symbol":"_MergedGlobals"},{"value":1},{"value":5335375360},{"value":1},{"value":0},{"value":4315883237},{"value":4317401088,"symbolLocation":120,"symbol":"_MergedGlobals"},{"value":4317472472,"symbolLocation":0,"symbol":"mono_profiler_state"}],"flavor":"ARM_THREAD_STATE64","lr":{"value":4312822820},"cpsr":{"value":2147487744},"fp":{"value":6173617904},"sp":{"value":6173617776},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825106352},"far":{"value":0}},"frames":[{"imageOffset":2992,"symbol":"semaphore_wait_trap","symbolLocation":8,"imageIndex":4},{"symbol":"mono_os_sem_wait","inline":true,"imageIndex":0,"imageOffset":15709220,"symbolLocation":12,"sourceLine":85,"sourceFile":"mono-os-semaphore.h"},{"symbol":"mono_coop_sem_wait","inline":true,"imageIndex":0,"imageOffset":15709220,"symbolLocation":44,"sourceLine":41,"sourceFile":"mono-coop-semaphore.h"},{"imageOffset":15709220,"sourceLine":891,"sourceFile":"gc.c","symbol":"finalizer_thread","imageIndex":0,"symbolLocation":340},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566084,"symbolLocation":280,"sourceLine":1202,"sourceFile":"threads.c"},{"imageOffset":15566084,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":348},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595159,"frames":[{"imageOffset":7020,"symbol":"start_wqthread","symbolLocation":0,"imageIndex":5}],"threadState":{"x":[{"value":6174191616},{"value":32515},{"value":6173655040},{"value":0},{"value":409604},{"value":18446744073709551615},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":0},"cpsr":{"value":4096},"fp":{"value":0},"sp":{"value":6174191616},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825356140},"far":{"value":0}}},{"id":595160,"frames":[{"imageOffset":7020,"symbol":"start_wqthread","symbolLocation":0,"imageIndex":5}],"threadState":{"x":[{"value":6174765056},{"value":32259},{"value":6174228480},{"value":0},{"value":409604},{"value":18446744073709551615},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":0},"cpsr":{"value":4096},"fp":{"value":0},"sp":{"value":6174765056},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825356140},"far":{"value":0}}},{"id":595164,"name":"com.apple.uikit.eventfetch-thread","threadState":{"x":[{"value":268451845},{"value":21592279046},{"value":8589934592},{"value":128655745351680},{"value":0},{"value":128655745351680},{"value":2},{"value":4294967295},{"value":0},{"value":17179869184},{"value":0},{"value":2},{"value":0},{"value":0},{"value":29955},{"value":0},{"value":18446744073709551569},{"value":8687557736},{"value":0},{"value":4294967295},{"value":2},{"value":128655745351680},{"value":0},{"value":128655745351680},{"value":6175333784},{"value":8589934592},{"value":21592279046},{"value":18446744073709550527},{"value":4412409862}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825182112},"cpsr":{"value":4096},"fp":{"value":6175333632},"sp":{"value":6175333552},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825106484},"far":{"value":0}},"frames":[{"imageOffset":3124,"symbol":"mach_msg2_trap","symbolLocation":8,"imageIndex":4},{"imageOffset":78752,"symbol":"mach_msg2_internal","symbolLocation":76,"imageIndex":4},{"imageOffset":38756,"symbol":"mach_msg_overwrite","symbolLocation":484,"imageIndex":4},{"imageOffset":4008,"symbol":"mach_msg","symbolLocation":24,"imageIndex":4},{"imageOffset":511164,"symbol":"__CFRunLoopServiceMachPort","symbolLocation":160,"imageIndex":13},{"imageOffset":505304,"symbol":"__CFRunLoopRun","symbolLocation":1208,"imageIndex":13},{"imageOffset":502424,"symbol":"CFRunLoopRunSpecific","symbolLocation":572,"imageIndex":13},{"imageOffset":367736,"symbol":"-[NSRunLoop(NSRunLoop) runMode:beforeDate:]","symbolLocation":212,"imageIndex":22},{"imageOffset":840612,"symbol":"-[NSRunLoop(NSRunLoop) runUntilDate:]","symbolLocation":100,"imageIndex":22},{"imageOffset":20592,"symbol":"-[UIEventFetcher threadMain]","symbolLocation":104,"imageIndex":10},{"imageOffset":342952,"symbol":"__NSThread__start__","symbolLocation":732,"imageIndex":22},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595165,"frames":[{"imageOffset":7020,"symbol":"start_wqthread","symbolLocation":0,"imageIndex":5}],"threadState":{"x":[{"value":6175911936},{"value":28675},{"value":6175375360},{"value":0},{"value":409604},{"value":18446744073709551615},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":0},"cpsr":{"value":4096},"fp":{"value":0},"sp":{"value":6175911936},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825356140},"far":{"value":0}}},{"id":595166,"frames":[{"imageOffset":7020,"symbol":"start_wqthread","symbolLocation":0,"imageIndex":5}],"threadState":{"x":[{"value":6176485376},{"value":28423},{"value":6175948800},{"value":0},{"value":409604},{"value":18446744073709551615},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":0},"cpsr":{"value":4096},"fp":{"value":0},"sp":{"value":6176485376},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825356140},"far":{"value":0}}},{"id":595171,"frames":[{"imageOffset":7020,"symbol":"start_wqthread","symbolLocation":0,"imageIndex":5}],"threadState":{"x":[{"value":6177058816},{"value":27655},{"value":6176522240},{"value":0},{"value":409604},{"value":18446744073709551615},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":0},"cpsr":{"value":4096},"fp":{"value":0},"sp":{"value":6177058816},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825356140},"far":{"value":0}}},{"id":595193,"name":"com.apple.NSEventThread","threadState":{"x":[{"value":268451845},{"value":21592279046},{"value":8589934592},{"value":278206506598400},{"value":0},{"value":278206506598400},{"value":2},{"value":4294967295},{"value":0},{"value":17179869184},{"value":0},{"value":2},{"value":0},{"value":0},{"value":64775},{"value":0},{"value":18446744073709551569},{"value":8687557736},{"value":0},{"value":4294967295},{"value":2},{"value":278206506598400},{"value":0},{"value":278206506598400},{"value":6177628296},{"value":8589934592},{"value":21592279046},{"value":18446744073709550527},{"value":4412409862}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825182112},"cpsr":{"value":4096},"fp":{"value":6177628144},"sp":{"value":6177628064},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825106484},"far":{"value":0}},"frames":[{"imageOffset":3124,"symbol":"mach_msg2_trap","symbolLocation":8,"imageIndex":4},{"imageOffset":78752,"symbol":"mach_msg2_internal","symbolLocation":76,"imageIndex":4},{"imageOffset":38756,"symbol":"mach_msg_overwrite","symbolLocation":484,"imageIndex":4},{"imageOffset":4008,"symbol":"mach_msg","symbolLocation":24,"imageIndex":4},{"imageOffset":511164,"symbol":"__CFRunLoopServiceMachPort","symbolLocation":160,"imageIndex":13},{"imageOffset":505304,"symbol":"__CFRunLoopRun","symbolLocation":1208,"imageIndex":13},{"imageOffset":502424,"symbol":"CFRunLoopRunSpecific","symbolLocation":572,"imageIndex":13},{"imageOffset":1435532,"symbol":"_NSEventThread","symbolLocation":140,"imageIndex":15},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595205,"name":".NET File Watcher","threadState":{"x":[{"value":268451845},{"value":21592279046},{"value":8589934592},{"value":216616675573760},{"value":0},{"value":216616675573760},{"value":2},{"value":4294967295},{"value":0},{"value":17179869184},{"value":0},{"value":2},{"value":0},{"value":0},{"value":50435},{"value":487445},{"value":18446744073709551569},{"value":8687564416},{"value":0},{"value":4294967295},{"value":2},{"value":216616675573760},{"value":0},{"value":216616675573760},{"value":6179771176},{"value":8589934592},{"value":21592279046},{"value":18446744073709550527},{"value":4412409862}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825182112},"cpsr":{"value":4096},"fp":{"value":6179771024},"sp":{"value":6179770944},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825106484},"far":{"value":0}},"frames":[{"imageOffset":3124,"symbol":"mach_msg2_trap","symbolLocation":8,"imageIndex":4},{"imageOffset":78752,"symbol":"mach_msg2_internal","symbolLocation":76,"imageIndex":4},{"imageOffset":38756,"symbol":"mach_msg_overwrite","symbolLocation":484,"imageIndex":4},{"imageOffset":4008,"symbol":"mach_msg","symbolLocation":24,"imageIndex":4},{"imageOffset":511164,"symbol":"__CFRunLoopServiceMachPort","symbolLocation":160,"imageIndex":13},{"imageOffset":505304,"symbol":"__CFRunLoopRun","symbolLocation":1208,"imageIndex":13},{"imageOffset":502424,"symbol":"CFRunLoopRunSpecific","symbolLocation":572,"imageIndex":13},{"imageOffset":1000788,"symbol":"CFRunLoopRun","symbolLocation":64,"imageIndex":13},{"imageOffset":16660792,"sourceLine":2244,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":92},{"imageOffset":16654264,"sourceLine":2350,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":356},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566328,"symbolLocation":524,"sourceLine":1213,"sourceFile":"threads.c"},{"imageOffset":15566328,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":592},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595209,"name":".NET Timer","threadState":{"x":[{"value":260},{"value":0},{"value":512},{"value":0},{"value":0},{"value":160},{"value":0},{"value":0},{"value":6181920936},{"value":0},{"value":0},{"value":2},{"value":2},{"value":0},{"value":0},{"value":0},{"value":305},{"value":8687555856},{"value":0},{"value":4768330768},{"value":4768330832},{"value":6181925088},{"value":0},{"value":0},{"value":512},{"value":769},{"value":1024},{"value":4768332856},{"value":4768924464}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825378016},"cpsr":{"value":1610616832},"fp":{"value":6181921056},"sp":{"value":6181920912},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825120716},"far":{"value":0}},"frames":[{"imageOffset":17356,"symbol":"__psynch_cvwait","symbolLocation":8,"imageIndex":4},{"imageOffset":28896,"symbol":"_pthread_cond_wait","symbolLocation":984,"imageIndex":5},{"imageOffset":16660824,"sourceLine":2256,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":124},{"imageOffset":16654264,"sourceLine":2350,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":356},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566328,"symbolLocation":524,"sourceLine":1213,"sourceFile":"threads.c"},{"imageOffset":15566328,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":592},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595210,"name":".NET TP Worker","threadState":{"x":[{"value":260},{"value":0},{"value":0},{"value":0},{"value":0},{"value":161},{"value":20},{"value":0},{"value":1},{"value":0},{"value":0},{"value":2},{"value":2},{"value":0},{"value":0},{"value":0},{"value":305},{"value":8687555856},{"value":0},{"value":4768368352},{"value":6184065360},{"value":1},{"value":0},{"value":20},{"value":0},{"value":1},{"value":256},{"value":4768375032},{"value":4789895664}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825378060},"cpsr":{"value":2684358656},"fp":{"value":6184065168},"sp":{"value":6184065024},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825120716},"far":{"value":0}},"frames":[{"imageOffset":17356,"symbol":"__psynch_cvwait","symbolLocation":8,"imageIndex":4},{"imageOffset":28940,"symbol":"_pthread_cond_wait","symbolLocation":1028,"imageIndex":5},{"imageOffset":14754156,"sourceLine":44,"sourceFile":"mono-os-mutex.c","symbol":"mono_os_cond_timedwait","imageIndex":0,"symbolLocation":96},{"symbol":"mono_coop_cond_timedwait","inline":true,"imageIndex":0,"imageOffset":14770940,"symbolLocation":32,"sourceLine":103,"sourceFile":"mono-coop-mutex.h"},{"imageOffset":14770940,"sourceLine":56,"sourceFile":"lifo-semaphore.c","symbol":"mono_lifo_semaphore_timed_wait","imageIndex":0,"symbolLocation":268},{"imageOffset":16660876,"sourceLine":2274,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":176},{"imageOffset":16654320,"sourceLine":2354,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":412},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566328,"symbolLocation":524,"sourceLine":1213,"sourceFile":"threads.c"},{"imageOffset":15566328,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":592},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595211,"name":".NET TP Gate","threadState":{"x":[{"value":260},{"value":0},{"value":0},{"value":0},{"value":0},{"value":160},{"value":0},{"value":500000000},{"value":1},{"value":0},{"value":0},{"value":2},{"value":2},{"value":0},{"value":0},{"value":0},{"value":305},{"value":8687555856},{"value":0},{"value":4768376976},{"value":4768377040},{"value":1},{"value":500000000},{"value":0},{"value":0},{"value":1},{"value":256},{"value":4765032888},{"value":4800480112}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825378060},"cpsr":{"value":2684358656},"fp":{"value":6184378672},"sp":{"value":6184378528},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825120716},"far":{"value":0}},"frames":[{"imageOffset":17356,"symbol":"__psynch_cvwait","symbolLocation":8,"imageIndex":4},{"imageOffset":28940,"symbol":"_pthread_cond_wait","symbolLocation":1028,"imageIndex":5},{"imageOffset":13227028,"sourceLine":177,"sourceFile":"pal_threading.c","symbol":"SystemNative_LowLevelMonitor_TimedWait","imageIndex":0,"symbolLocation":88},{"imageOffset":16660876,"sourceLine":2274,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":176},{"imageOffset":16654264,"sourceLine":2350,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":356},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566328,"symbolLocation":524,"sourceLine":1213,"sourceFile":"threads.c"},{"imageOffset":15566328,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":592},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595212,"name":".NET TP Worker","threadState":{"x":[{"value":260},{"value":0},{"value":0},{"value":0},{"value":0},{"value":161},{"value":20},{"value":0},{"value":1},{"value":0},{"value":0},{"value":2},{"value":2},{"value":0},{"value":0},{"value":0},{"value":305},{"value":8687555856},{"value":0},{"value":4768368352},{"value":6186524928},{"value":1},{"value":0},{"value":20},{"value":0},{"value":1},{"value":256},{"value":4766018296},{"value":4801528256}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825378060},"cpsr":{"value":2684358656},"fp":{"value":6186524736},"sp":{"value":6186524592},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825120716},"far":{"value":0}},"frames":[{"imageOffset":17356,"symbol":"__psynch_cvwait","symbolLocation":8,"imageIndex":4},{"imageOffset":28940,"symbol":"_pthread_cond_wait","symbolLocation":1028,"imageIndex":5},{"imageOffset":14754156,"sourceLine":44,"sourceFile":"mono-os-mutex.c","symbol":"mono_os_cond_timedwait","imageIndex":0,"symbolLocation":96},{"symbol":"mono_coop_cond_timedwait","inline":true,"imageIndex":0,"imageOffset":14770940,"symbolLocation":32,"sourceLine":103,"sourceFile":"mono-coop-mutex.h"},{"imageOffset":14770940,"sourceLine":56,"sourceFile":"lifo-semaphore.c","symbol":"mono_lifo_semaphore_timed_wait","imageIndex":0,"symbolLocation":268},{"imageOffset":16660876,"sourceLine":2274,"sourceFile":"interp.c","symbol":"do_icall","imageIndex":0,"symbolLocation":176},{"imageOffset":16654320,"sourceLine":2354,"sourceFile":"interp.c","symbol":"do_icall_wrapper","imageIndex":0,"symbolLocation":412},{"imageOffset":16610712,"sourceFile":"interp.c","symbol":"mono_interp_exec_method","symbolLocation":2832,"imageIndex":0},{"imageOffset":16601516,"sourceLine":2109,"sourceFile":"interp.c","symbol":"interp_runtime_invoke","imageIndex":0,"symbolLocation":244},{"imageOffset":15873208,"sourceLine":3683,"sourceFile":"mini-runtime.c","symbol":"mono_jit_runtime_invoke","imageIndex":0,"symbolLocation":1320},{"symbol":"do_runtime_invoke","inline":true,"imageIndex":0,"imageOffset":15482496,"symbolLocation":60,"sourceLine":2576,"sourceFile":"object.c"},{"imageOffset":15482496,"sourceLine":2792,"sourceFile":"object.c","symbol":"mono_runtime_invoke_checked","imageIndex":0,"symbolLocation":148},{"symbol":"start_wrapper_internal","inline":true,"imageIndex":0,"imageOffset":15566328,"symbolLocation":524,"sourceLine":1213,"sourceFile":"threads.c"},{"imageOffset":15566328,"sourceLine":1271,"sourceFile":"threads.c","symbol":"start_wrapper","imageIndex":0,"symbolLocation":592},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]},{"id":595214,"name":"HIE: M_ aa2747e30da52f49 2025-09-18 08:24:00.427","threadState":{"x":[{"value":0},{"value":8589934595},{"value":103079220499},{"value":283686884920579},{"value":15483357102080},{"value":283686884868096},{"value":44},{"value":0},{"value":6825316352,"symbolLocation":40,"symbol":"mach_voucher_debug_info"},{"value":1},{"value":4450099621},{"value":7},{"value":5},{"value":4772658944},{"value":8670427736,"symbolLocation":0,"symbol":"_NSConcreteMallocBlock"},{"value":8670427736,"symbolLocation":0,"symbol":"_NSConcreteMallocBlock"},{"value":18446744073709551569},{"value":8687560872},{"value":0},{"value":0},{"value":44},{"value":283686884868096},{"value":15483357102080},{"value":283686884920579},{"value":6187101456},{"value":103079220499},{"value":8589934595},{"value":18446744073709550527},{"value":0}],"flavor":"ARM_THREAD_STATE64","lr":{"value":6825182112},"cpsr":{"value":2147487744},"fp":{"value":6187101440},"sp":{"value":6187101360},"esr":{"value":1442840704,"description":" Address size fault"},"pc":{"value":6825106484},"far":{"value":0}},"frames":[{"imageOffset":3124,"symbol":"mach_msg2_trap","symbolLocation":8,"imageIndex":4},{"imageOffset":78752,"symbol":"mach_msg2_internal","symbolLocation":76,"imageIndex":4},{"imageOffset":198788,"symbol":"thread_suspend","symbolLocation":108,"imageIndex":4},{"imageOffset":222468,"symbol":"SOME_OTHER_THREAD_SWALLOWED_AT_LEAST_ONE_EXCEPTION","symbolLocation":20,"imageIndex":21},{"imageOffset":342952,"symbol":"__NSThread__start__","symbolLocation":732,"imageIndex":22},{"imageOffset":27660,"symbol":"_pthread_start","symbolLocation":136,"imageIndex":5},{"imageOffset":7040,"symbol":"thread_start","symbolLocation":8,"imageIndex":5}]}],
  "usedImages" : [
  {
    "source" : "P",
    "arch" : "arm64",
    "base" : 4297113600,
    "CFBundleShortVersionString" : "1.0",
    "CFBundleIdentifier" : "com.companyname.bibleshow.ui",
    "size" : 19316736,
    "uuid" : "39fea836-ca8a-3221-807e-302a2ac4491a",
    "path" : "\/Users\/USER\/Documents\/*\/BibleShow.UI.app\/Contents\/MacOS\/BibleShow.UI",
    "name" : "BibleShow.UI",
    "CFBundleVersion" : "1"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 4326621184,
    "CFBundleShortVersionString" : "1.0",
    "CFBundleIdentifier" : "com.apple.AutomaticAssessmentConfiguration",
    "size" : 32768,
    "uuid" : "e4472d7d-c96b-366d-8cac-05161cedfc12",
    "path" : "\/System\/Library\/Frameworks\/AutomaticAssessmentConfiguration.framework\/Versions\/A\/AutomaticAssessmentConfiguration",
    "name" : "AutomaticAssessmentConfiguration",
    "CFBundleVersion" : "12.0.0"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 4327374848,
    "size" : 49152,
    "uuid" : "a3faee04-0f8b-3428-9497-560c97eca6fb",
    "path" : "\/usr\/lib\/libobjc-trampolines.dylib",
    "name" : "libobjc-trampolines.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 4791697408,
    "CFBundleShortVersionString" : "329.2",
    "CFBundleIdentifier" : "com.apple.AGXMetal13-3",
    "size" : 6897664,
    "uuid" : "b303b4e8-5f17-39b8-8505-326aaf870f39",
    "path" : "\/System\/Library\/Extensions\/AGXMetal13_3.bundle\/Contents\/MacOS\/AGXMetal13_3",
    "name" : "AGXMetal13_3",
    "CFBundleVersion" : "329.2"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6825103360,
    "size" : 243284,
    "uuid" : "6e4a96ad-04b8-3e8a-b91d-087e62306246",
    "path" : "\/usr\/lib\/system\/libsystem_kernel.dylib",
    "name" : "libsystem_kernel.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6825349120,
    "size" : 51784,
    "uuid" : "d6494ba9-171e-39fc-b1aa-28ecf87975d1",
    "path" : "\/usr\/lib\/system\/libsystem_pthread.dylib",
    "name" : "libsystem_pthread.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6823870464,
    "size" : 528964,
    "uuid" : "dfea8794-80ce-37c3-8f6a-108aa1d0b1b0",
    "path" : "\/usr\/lib\/system\/libsystem_c.dylib",
    "name" : "libsystem_c.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6825598976,
    "size" : 32268,
    "uuid" : "fd19a599-8750-31f9-924f-c2810c938371",
    "path" : "\/usr\/lib\/system\/libsystem_platform.dylib",
    "name" : "libsystem_platform.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6824980480,
    "size" : 122880,
    "uuid" : "776a4afb-71ee-32ab-b2ee-e6ff80818654",
    "path" : "\/usr\/lib\/libc++abi.dylib",
    "name" : "libc++abi.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6821199872,
    "size" : 342164,
    "uuid" : "8ca52e4d-f699-3d14-8061-eea9d4366538",
    "path" : "\/usr\/lib\/libobjc.A.dylib",
    "name" : "libobjc.A.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 7689256960,
    "CFBundleShortVersionString" : "1.0",
    "CFBundleIdentifier" : "com.apple.UIKitCore",
    "size" : 31020000,
    "uuid" : "0afe2622-c672-3033-85cb-b9715072bd79",
    "path" : "\/System\/iOSSupport\/System\/Library\/PrivateFrameworks\/UIKitCore.framework\/Versions\/A\/UIKitCore",
    "name" : "UIKitCore",
    "CFBundleVersion" : "8605"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 7221841920,
    "CFBundleShortVersionString" : "943.6.1",
    "CFBundleIdentifier" : "com.apple.FrontBoardServices",
    "size" : 836544,
    "uuid" : "ac6831d1-8a69-3ecc-a85c-5f6c0538a749",
    "path" : "\/System\/Library\/PrivateFrameworks\/FrontBoardServices.framework\/Versions\/A\/FrontBoardServices",
    "name" : "FrontBoardServices",
    "CFBundleVersion" : "943.6.1"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6823567360,
    "size" : 288608,
    "uuid" : "24ce0d89-4114-30c2-a81a-3db1f5931cff",
    "path" : "\/usr\/lib\/system\/libdispatch.dylib",
    "name" : "libdispatch.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6825828352,
    "CFBundleShortVersionString" : "6.9",
    "CFBundleIdentifier" : "com.apple.CoreFoundation",
    "size" : 5500928,
    "uuid" : "8d45baee-6cc0-3b89-93fd-ea1c8e15c6d7",
    "path" : "\/System\/Library\/Frameworks\/CoreFoundation.framework\/Versions\/A\/CoreFoundation",
    "name" : "CoreFoundation",
    "CFBundleVersion" : "3603"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 7021232128,
    "CFBundleShortVersionString" : "2.1.1",
    "CFBundleIdentifier" : "com.apple.HIToolbox",
    "size" : 3174368,
    "uuid" : "1a037942-11e0-3fc8-aad2-20b11e7ae1a4",
    "path" : "\/System\/Library\/Frameworks\/Carbon.framework\/Versions\/A\/Frameworks\/HIToolbox.framework\/Versions\/A\/HIToolbox",
    "name" : "HIToolbox"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6892302336,
    "CFBundleShortVersionString" : "6.9",
    "CFBundleIdentifier" : "com.apple.AppKit",
    "size" : 21564992,
    "uuid" : "860c164c-d04c-30ff-8c6f-e672b74caf11",
    "path" : "\/System\/Library\/Frameworks\/AppKit.framework\/Versions\/C\/AppKit",
    "name" : "AppKit",
    "CFBundleVersion" : "2575.70.52"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 7284772864,
    "CFBundleShortVersionString" : "1.0",
    "CFBundleIdentifier" : "com.apple.UIKitMacHelper",
    "size" : 1167552,
    "uuid" : "a6ad07bb-52c9-3512-a568-9a2f1a78a73e",
    "path" : "\/System\/Library\/PrivateFrameworks\/UIKitMacHelper.framework\/Versions\/A\/UIKitMacHelper",
    "name" : "UIKitMacHelper",
    "CFBundleVersion" : "8605"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6821543936,
    "size" : 636280,
    "uuid" : "3247e185-ced2-36ff-9e29-47a77c23e004",
    "path" : "\/usr\/lib\/dyld",
    "name" : "dyld"
  },
  {
    "size" : 0,
    "source" : "A",
    "base" : 0,
    "uuid" : "00000000-0000-0000-0000-000000000000"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 7404429312,
    "CFBundleShortVersionString" : "1.0",
    "CFBundleIdentifier" : "com.apple.accessibility.AXCoreUtilities",
    "size" : 767520,
    "uuid" : "6adcd8e5-3ab2-3c1c-970c-3eddee222eed",
    "path" : "\/System\/Library\/PrivateFrameworks\/AXCoreUtilities.framework\/Versions\/A\/AXCoreUtilities",
    "name" : "AXCoreUtilities",
    "CFBundleVersion" : "1"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6822506496,
    "size" : 112640,
    "uuid" : "ac8466b8-af1d-3895-876b-228151f0df1d",
    "path" : "\/usr\/lib\/system\/libsystem_trace.dylib",
    "name" : "libsystem_trace.dylib"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6941020160,
    "CFBundleShortVersionString" : "1.22",
    "CFBundleIdentifier" : "com.apple.HIServices",
    "size" : 443296,
    "uuid" : "3c31e34f-3cfd-3469-b90d-23da674476b3",
    "path" : "\/System\/Library\/Frameworks\/ApplicationServices.framework\/Versions\/A\/Frameworks\/HIServices.framework\/Versions\/A\/HIServices",
    "name" : "HIServices"
  },
  {
    "source" : "P",
    "arch" : "arm64e",
    "base" : 6848835584,
    "CFBundleShortVersionString" : "6.9",
    "CFBundleIdentifier" : "com.apple.Foundation",
    "size" : 14587296,
    "uuid" : "b9a92060-f21e-3ecf-9ded-94a65c68a6f4",
    "path" : "\/System\/Library\/Frameworks\/Foundation.framework\/Versions\/C\/Foundation",
    "name" : "Foundation",
    "CFBundleVersion" : "3603"
  }
],
  "sharedCache" : {
  "base" : 6820708352,
  "size" : 5040898048,
  "uuid" : "4c1223e5-cace-3982-a003-6110a7a8a25c"
},
  "vmSummary" : "ReadOnly portion of Libraries: Total=1.8G resident=0K(0%) swapped_out_or_unallocated=1.8G(100%)\nWritable regions: Total=746.2M written=691K(0%) resident=691K(0%) swapped_out=0K(0%) unallocated=745.5M(100%)\n\n                                VIRTUAL   REGION \nREGION TYPE                        SIZE    COUNT (non-coalesced) \n===========                     =======  ======= \nActivity Tracing                   256K        1 \nColorSync                          528K       27 \nCoreAnimation                      512K       32 \nCoreGraphics                        32K        2 \nCoreServices                       208K        1 \nDispatch continuations            64.0M        1 \nFoundation                          16K        1 \nKernel Alloc Once                   32K        1 \nMALLOC                           620.4M       59 \nMALLOC guard page                  288K       18 \nMALLOC_SMALL                        16K        1 \nSTACK GUARD                       56.3M       18 \nStack                             24.3M       18 \nVM_ALLOCATE                       36.4M       47 \n__AUTH                            7229K      820 \n__AUTH_CONST                      87.1M     1070 \n__CTF                               824        1 \n__DATA                            29.5M     1046 \n__DATA_CONST                      29.9M     1080 \n__DATA_DIRTY                      2855K      357 \n__FONT_DATA                        2352        1 \n__INFO_FILTER                         8        1 \n__LINKEDIT                       626.9M        5 \n__OBJC_RO                         61.4M        1 \n__OBJC_RW                         2396K        1 \n__TEXT                             1.2G     1104 \n__TPRO_CONST                       128K        2 \nmapped file                      290.0M      123 \npage table in kernel               691K        1 \nshared memory                      864K       13 \n===========                     =======  ======= \nTOTAL                              3.1G     5853 \n",
  "legacyInfo" : {
  "threadTriggered" : {
    "name" : "tid_103",
    "queue" : "com.apple.main-thread"
  }
},
  "logWritingSignature" : "af637b170c9649167e5560f975a74ec5acdc2b43",
  "trialInfo" : {
  "rollouts" : [
    {
      "rolloutId" : "654439cdafbf5b61207873a9",
      "factorPackIds" : {

      },
      "deploymentId" : 240000004
    },
    {
      "rolloutId" : "6246d6a916a70b047e454124",
      "factorPackIds" : {

      },
      "deploymentId" : 240000010
    }
  ],
  "experiments" : [

  ]
}
}

