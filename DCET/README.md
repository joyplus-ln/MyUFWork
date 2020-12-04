## 简介

DCET是Unity3D客户端和.Net Core服务器的双端框架。

## DCET与ET的差异

DCET是基于ET4.0、5.0、6.0进行二次开发的分支版本，主要差异如下：

* 移除UGUI模块；
* 新增FGUI模块，包括UI加载、UI管理、UI控件管理代码自动生成插件等完整的FGUI工作流；
* 新增行为树模块，包括可视化编辑器、双端运行时、逻辑全热更的完整的行为树工作流；
* 新增Lua模块，包括CSharp.Lua（自动翻译热更层代码为Lua）、xLua(执行CSharp.Lua翻译的热更层Lua代码)、RapidJson、lua-protobuf、LuaSocket、LPeg、FFI for lua53等完整的Lua热更工作流。
* 将框架模块化，并使用Unity的PackageManager进行管理，可以根据项目需求，按需选择模块引用。同时将框架和游戏业务分离，使维护框架代码更方便。

## 入门

#### 1.搭建环境

​		第一步：下载DCET，下载的方式分为三种：

- 直接下载压缩包，通过下载地址：[`https://github.com/DukeChiang/DCET/archive/dukechiang_master.zip`](https://github.com/DukeChiang/DCET/archive/dukechiang_master.zip)，进行下载。
- 使用Git命令进行下载，通过Git命令行工具，输入：`git clone https://github.com/DukeChiang/DCET.git 目标文件夹(如：D:/WorkSpace/DCET)`，回车即可下载。
- 使用SourceTree等可视化工具进行下载，找到Clone功能，输入源路径：`https://github.com/DukeChiang/DCET.git`，选择目标路径：`D:/WorkSpace/DCET（示例）`，然后点击Clone。如果Clone失败，可以尝试方式2进行下载，然后使用Add功能进行可视化管理。

​		第二步：下载并安装Unity2018.4.12f1，有两种下载方式，根据自己的情况选择一种方式下载，只需要能正常使用相应版本的Unity即可，理论上是支持大多数的Unity的版本的，不过由于Unity版本众多，如果需要在其他版本的Unity中使用，需自行适配。下载地址如下：

- 中国版下载地址：[`https://unity.cn/releases`](https://unity.cn/releases)
- 国际版下载地址：[`https://unity3d.com/get-unity/download/archive`](https://unity3d.com/get-unity/download/archive) (需要科学上网才能下载)

​		第三步：安装VS2019，在安装Unity时，可以选择安装VS2019，或者通过VS官网下载([`https://visualstudio.microsoft.com/zh-hans/thank-you-downloading-visual-studio/?sku=Community&rel=16`](https://visualstudio.microsoft.com/zh-hans/thank-you-downloading-visual-studio/?sku=Community&rel=16))，然后安装的时候选择：.NET桌面开发、使用C++桌面开发、使用Unity的游戏开发(可以去掉Unity编辑器安装)、使用C++的Linux开发、.Net Core跨平台开发。推荐安装以上组件，在DCET开发中都可能用到。

#### 2.运行指南

​		第一步：启动服务器：搭建环境完成之后，打开Server/Server.sln解决方案，点击生成解决方案，如果控制台输出的日志中，所有项目都生成成功，即可点击“Start”启动服务器。如果控制台输出的日志中提示存在生成失败的项目，则很可能是环境不全导致，右键点击“DCET.Init”项目，点击属性，查看目标框架.NET Core 3.0是否正常安装，如果未安装，则需要下载并安装([`https://dotnet.microsoft.com/download`](https://dotnet.microsoft.com/download))，如果安装之后，目标框架依然没有.NET Core 3.0，说明VS版本过低，更新到最新版即可解决。

​		第二步：启动客户端：打开Unity2018.4.12f1，点击Open，选择DCET路径下的Unity目录，点击选择文件夹，即可启动DCET客户端。此时，打开“Scenes/Init”场景，点击运行按钮，即可成功运行，点击登录，点击进入地图，然后就可以右键点击屏幕，看到骷髅移动的状态同步的官方示例。如果运行中，点击登录提示`“System.Exception: Rpc error”`，一般情况下是服务器未成功启动，需要检查第一步是否未完成。如果运行中，出现异常`“XLua.LuaException: F:/DukeChiangGit/ET/Unity/Assets\Res/Lua/Hotfix/Message/AutoGeneratedCode/OuterMessage.lua.txt:600: attempt to call a nil value (method 'setIsRequired')”`，一般情况下是未生成Wrap文件，点击菜单栏XLua/Generate Code生成即可。

#### 3.开发指南

​		为了框架代码维护更方便，且按需引用更方便，现已将框架模块化，并通过Unity的[PackageManager](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.0/manual/index.html)和[Assembly Definition](https://docs.unity3d.com/Manual/class-AssemblyDefinitionImporter.html)进行管理，所以相对于ET的目录结构会存在一定的差异，但实际功能几乎没有差别。下文将分别阐述服务器和客户端的开发指南。

- 服务器：服务器代码所在目录为`DCET/Server`，并通过`DCET/Server/Server.sln`解决方案管理所有项目(包括框架和游戏业务)，框架代码所在目录为`DCET/Server/Packages`，具体的项目将在进阶文档中详细介绍。游戏业务代码所在目录为`DCET/Server/Assets`，分为`Init、Runtime、Hotfix、Benchmark`四个项目，其中Init为入口项目，Runtime为非热更项目、Hotfix为热更项目、Benchmark为测试项目，依赖关系为Init→Benchmark→Hotfix→Runtime。
- 客户端：客户代码所在目录为`DCET/Unity`，并通过`DCET/Unity/Unity.sln`解决方案管理所有项目(包括框架和游戏业务)，框架代码所在目录为`DCET/Unity/Packages`，具体的项目将在进阶文档中详细介绍。游戏业务代码所在目录为`DCET/Unity/Assets`，分为`Runtime、Hotfix、Editor`三个项目，其中Runtime为入口项目和非热更项目、Hotfix为热更项目、Editor为编辑器项目，依赖关系为Editor→Hotfix→Runtime，Runtime通过反射或Lua的方式启动Hotfix，所以不需要Runtime依赖Hotfix。

​	值得注意的是框架和游戏业务的依赖关系为：**游戏业务→框架**，依赖不当将导致项目混乱，不利于维护。

​	注：“A→B”表示A引用B，可以理解为A可以调用B，B不可以调用A。

## 进阶

#### 1.模块概述

​		DCET分为核心、下载器、配置、网络、协程锁、数值、寻路、行为树、FGUI、Lua模块， 每个模块一般分为Editor、Runtime、Hotfix三个项目（程序集），其中Editor为编辑器相关功能，Runtime为非热更相关功能，Hotfix为热更相关功能，依赖关系为Editor→Hotfix→Runtime。而模块间的依赖关系为Lua模块→其他模块→核心模块，用户可以遵循依赖关系轻松的移除或新增模块。

​		注：客户端引用通过[Assembly Definition](https://docs.unity3d.com/Manual/class-AssemblyDefinitionImporter.html)进行管理，扩展名为`.asmdef`，存放于各模块的各个文件夹根目录；服务器引用通过`项目名/依赖项`右键进行管理。

#### 2.核心模块

​		核心模块是其他模块的基础，主要提供实体化(组件化)和事件系统的基础功能支持，也是ET框架设计中最为精髓的部分。所在目录为：`Packages/DCET.Core`，下文将重点介绍这两个方面：

- Entity

  ​		Entity即为实体，是经过纯粹的ECS不断改良而来的实体化开发思想，他与Unity的GameObject有一定的相似之处，但又截然不同，具体的不同点在于Unity是采用的Entity+Component的设计思想，而ET采用的是一切皆Entity的设计思想，同时Entity也拥有Component的能力，这种设计将为代码组织和重用带来极大的便利，整个代码结构就可以像树状图一样清晰，并且代码也将可以像树枝一样被轻松的组合重用。举个例子，角色有技能列表，各个技能操作方式不同，有直接使用型、有充能型。

  ```c#
  public class Role : Entity
  {
  	// 角色相关信息    
  }
  
  public class SkillComponent : Entity
  {
      private readonly Dictionary<long, Skill> idSkills = new Dictionary<long, Skill>();
      
      // 技能增删查等管理方法
  }
  
  public class Skill : Entity
  {
      // 技能相关信息
  }
  
  public class SkillChargeComponent : Entity
  {
      public void Start()
      {
      	// 充能开始    
      }
      
      public void End()
      {
          // 充能结束
      }
  }
  ```

  ​		根据以上示例可以看出，当为充能型技能时，可以为Skill加上SkillChargeComponent组件，技能释放时就可以走充能逻辑；当技能为直接释放型技能时，则不需要加SkillChargeComponent组件，也就不会走充能逻辑，这样一来则可以轻松重用代码逻辑，并且代码组织结构也十分清晰。

  ​		此外，Entity与Unity的MonoBehaviour一样存在生命周期，而ET的生命周期实现方式略有不同，是通过Attribute标记和启动时根据标记信息自动注册，然后根据生命周期执行，具体用法如下：

  ```c#
  [ObjectSystem]
  public class TestComponentAwakeSystem : AwakeSystem<TestComponent, string>
  {
      public override void Awake(TestComponent self, string param1)
      {
          self.Awake(param1);
      }
  }
  
  [ObjectSystem]
  public class TestComponentLoadSystem : LoadSystem<TestComponent>
  {
      public override void Load(TestComponent self)
      {
          self.Load();
      }
  }
  
  [ObjectSystem]
  public class TestComponentUpdateSystem : UpdateSystem<TestComponent>
  {
      public override void Update(TestComponent self)
      {
          self.Update();
      }
  }
  
  [ObjectSystem]
  public class TestComponentLateUpdateSystem : LateUpdateSystem<TestComponent>
  {
      public override void LateUpdate(TestComponent self)
      {
          self.LateUpdate();
      }
  }
  
  [ObjectSystem]
  public class TestComponentDestroySystem : DestroySystem<TestComponent>
  {
      public override void Destroy(TestComponent self)
      {
          self.Destroy();
      }
  }
  ```

- EventSystem

  ​		EventSystem即为事件系统，是解耦的重要方式。代码和现实世界一样，有着千丝万缕的`联系`，如果所有的`联系`都如同乱麻一般紧密的耦合在一起，将对代码的维护造成巨大的困难。这时候就需要将代码以`类`为单位，将`类引用`和`事件(或委托)`作为`联系`的桥梁，其中`类引用`是一种强联系的方式，这种方式是最直接，最简单，最方便，最紧密的联系方式，但如果仅仅只用这种联系方式也会造成代码混乱，耦合紧密，难以重用，难以维护的结果。这时候也就需要`事件(或委托)`进行联系，也就是解耦(一种弱联系)，当被引用类同时需要引用引用类时，就需要通过这种方式进行联系，这种方式是能为重用创作条件、避免代码形成网状结构的联系方式。最终代码结构就形成树状结构，清晰明了，利于重用和维护。

  ​		ET的事件系统实现方式，与上文提到的生命周期实现方式原理相同，具体的用法如下：

  ```c#
  // 发起事件
  Game.EventSystem.Run(EventIdType.Log, "Hello World");
  
  // 捕获事件
  [Event(EventIdType.Log)]
  public class Log_WriteLine: AEvent<string>
  {
      public override void Run(string param1)
      {
          Console.WriteLine(param1);
      }
  }
  ```

#### 3.AssetBundle模块

​		AssetBundle模块主要负责资源打包、管理、下载等功能，所在目录为：`Packages/DCET.AssetBundle`，具体的使用方法如下：

​		配置资源服务器地址和服务器地址：Tools/Start Global Config

​		构建资源包和安装包：Tools/Build Installer (默认只会打包`Init`场景)

​		启动资源服：Tools/Start Asset Server

​		资源管理组件：Hotfix/ResourcesComponent.cs

#### 4.配置模块

​		配置模块主要负责Excel配置表导出、解析、管理等功能，所在目录为：`Packages/DCET.Config`，具体的使用方法如下：

​		Excel配置表导出：Tools/Start Config

​		配置表管理组件：Hotfix/ConfigComponent.cs

#### 5.网络模块

​		网络模块主要负责网络消息收发、消息序列化/反序列化、消息管理、TCP/KCP传输协议，服务器启动、更新、管理等功能，所在目录为：`Packages/DCET.Config`，具体使用方法如下：

​		生成Protobuf消息协议：Tools/Gen Proto

​		服务器同步：Tools/Rsync

​		服务器命令行：Tools/Start Server Command

​		服务器重载：Tools/Start Server Manager

​		消息分发组件：MessageDispatcherComponent.cs

​		网络数据发送组件：NetOuterComponent.cs (可以配置TCP/KCP/WebSocket传输协议)

​		网络数据接收组件：NetInnerComponent.cs  (可以配置TCP/KCP/WebSocket传输协议)

#### 6.协程锁模块

#### 7.数值模块

#### 8.寻路模块

#### 9.行为树模块

#### 10.FGUI模块

#### 11.Lua模块

## 高级

#### 1.xLua+CSharp.Lua适配原理

## FAQ

待更新

## 技术支持

ET群：474643097

DCET新群：1105670843

ET官网：[`http://bbs.etframework.net/`](http://bbs.etframework.net/)