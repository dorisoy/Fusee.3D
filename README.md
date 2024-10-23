# 什么是 FUSEE？

FUSEE 是一款用 C# 编写的开源 3D 实时引擎。基于 FUSEE 编写的应用程序可以发布到多个平台。

# 使用 Blender 创建 3D 内容
可以使用免费的 Blender 3D 建模软件生成FUSEE 应用程序 (资产)中显示的 3D 内容。

FUSEE 附带 Blender 导出插件。 您可以将 Blender 内容保存为资产，并通过 FUSEE 应用程序中的 C# 代码访问它们 ，也可以直接从 Blender 内容生成整个交互式 Web 应用程序，而无需编写一行代码。

# 使用 Visual Studio Code 编写 3D 应用
使用流行的轻量级代码编辑器创建 FUSEE 应用，调试代码并将应用发布到支持的平台。生成的代码建立在 .NET core 之上，这是不同 .NET 实现中独立于开源平台的变体。
FUSEE 附带 .NET 核心模板。只需dotnet new fusee在命令行中输入即可开始在 VS Code 中编写 FUSEE 应用。

# 在不同的平台上发布你的应用
.NET App。这会将您的应用程序代码嵌入到 .NET Framework 3D 应用程序中，并将所有必要的文件捆绑到一个目录中。
Android。使用 Xamarin，您的代码将转换为原生 Android apk。目前，Xamarin 构建尚未集成到 FUSEE Visual Studio Code 构建过程中。要从您的 FUSEE 项目创建 Android 应用程序，您需要从 FUSEE GitHub 存储库获取 FUSEE 源。

# 先决条件
在安装FUSEE之前，请确保已安装以下软件。

# Blender （可选）
使用开源 3D 建模软件Blender创建 3D 模型，并将其用作 FUSEE 应用程序中的资产。FUSEE 安装将尝试检测您机器上的 Blender 安装，并将安装 FUSEE Blender 插件。

从https://www.blender.org/download/安装Blender

# .NET SDK（必需）
FUSEE 应用程序是使用 .NET SDK（版本 6 或更高版本）创建的 - 基于 OpenSource 构建的独立于平台的 .NET Framework。

从 https://www.microsoft.com/net/download/安装 .NET SDK

# Visual Studio Code（必需）
编辑您的 FUSEE App 源代码，调试您的应用程序的功能，构建您的应用程序并将其从流行的 OpenSource 轻量级代码编辑器中发布到支持的平台。

从https://code.visualstudio.com/download安装 Visual Studio Code

# 扩展：C# Dev Kit（必需）
要在 Visual Studio Code 中开发 C#/.NET 应用程序，需要一个扩展： [https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
从上面的链接安装 C# Dev Kit Extension 或者 打开 Visual Studio Code
打开Extensions窗格 ( Ctrl+Shift+X)
C#在搜索框中输入
从搜索结果中安装“C# Dev Kit”扩展


# 安装
[https://fusee3d.org/getting-started/install-fusee.html](https://fusee3d.org/getting-started/install-fusee.html)



| master | develop |
| ------ | ------- |
| [![CI](https://github.com/FUSEEProjectTeam/Fusee/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/FUSEEProjectTeam/Fusee/actions/workflows/ci.yml) | [![CI](https://github.com/FUSEEProjectTeam/Fusee/actions/workflows/ci.yml/badge.svg?branch=develop)](https://github.com/FUSEEProjectTeam/Fusee/actions/workflows/ci.yml) |

Use Fusee in your project: [![Nuget](https://img.shields.io/nuget/v/Fusee.Core?style=flat)](https://www.nuget.org/profiles/FUSEEProjectTeam)
