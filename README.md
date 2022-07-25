# 测试项目

## 结构

测试相关代码由两类测试构成

- Bootstrap测试。 一些核心的，必须由AOT部分发起才能校验正确性的测试，包含以下几类
  - interpreter到AOT的返回值的测试
  - AOT到interpreter传参测试
  - interpreter调用AOT函数的测试
- 普通测试。 由解释器内部自省即可完成的测试

## 运行方式

- 测试huatuo前先在editor下运行，确保通过所有测试用例
- 打包测试工程的方式与hybridclr_trial工程类似，但没有使用ab。将aot dll（需要先build游戏一次生成它们）及BoostrapTests.dll及Tests.dll拷入StreamingAssets再打包即可。Win下可以省去上面所有手动操作，快捷使用 `HybridCLR -> Build -> Win64` 命令直接一键打包及运行。
- 启动打包后的测试程序，进入第一个场景后，会自动运行运行所有c#测试用例。所有测试用例的结果都写入{Application.persistentPath}/test.log文件，接着进程自动退出。
- 如果在win平台，在运行结束后会自动打开test.log文件。

## 添加测试

### Bootstrap测试

由于其特殊性，Bootstrap测试无法自省完成，需要由AOT部分来验证。因此代码由两部分代码构成：

- AOT部分代码在 Assets/Main/BootstrapTests 目录
- interpreter部分代码在 Assets/BootstrapTests 目录

#### 测试类

- 测试类遵从 TC_xxxx 的命名规则
- 从GeneralTestCaseBase类继承。
- AOT部分 最顶层命名空间必须为 BootstrapTests，也可以是更具体一点的子命名空间，这样不容易与其他测试用例冲突，例如 BootstrapTests.Delegates。
- interpreter 为被测试部分，它并不是测试用例，不从 GeneralTestCaseBase类继承。它的命名空间同样也是BootstrapTests。

#### 测试用例

每个测试函数为一个测试用例。

- 测试用例须为成员函数，返回值为void且参数个数为0
- 测试函数必须包含`[UnitTest]`注解
- 使用SharpUnit.Assert 之类的函数进行测试断言

示例代码如下：

```c#
using SharpUnit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BootstrapTests
{
    public class TC_Arg : GeneralTestCaseBase
    {

        [UnitTest]
        public void Arg_bool()
        {
            // 一般来说 Bootstrap 测试需要测试interpreter代码
            // 来完成测试内容
            Assert.Equal(1, Call2<bool, int>("Arg_bool", true));
        }
    }
}


```

### 普通测试

测试正确性由interpreter部分配合`SharpUnit.Assert`自省完成，因此所有代码都在Test interpreter模块。
代码在 `Assets/Tests` 目录下。

由于测试用例非常多，Tests目录下还分了几个大类如

- Instruments 包含对指令集的测试用例
- CSharp 包含对c#语法的测试用例
- Bugs 包含单独零散反馈的bug的测试用例
- Mics 包含杂项测试用例

#### 测试类

- 从GeneralTestCaseBase类继承。
- 最顶层命名空间必须为 Tests，也可以是更具体一点的子命名空间，这样不容易与其他测试用例冲突，例如 Tests.Delegates。

#### 测试用例

每个测试函数为一个测试用例。

- 测试用例须为成员函数，返回值为void且参数个数为0
- 测试函数必须包含`[UnitTest]`注解
- 使用SharpUnit.Assert 之类的函数进行测试断言

```csharp

namespace Tests.Instruments
{
    internal class TC_add : GeneralTestCaseBase
    {

        [UnitTest]
        public void int_var_var()
        {
            int a = 5;
            int b = 3;
            Assert.Equal(8, a + b);
        }

        [UnitTest]
        public void int_var_const()
        {
            int a = 5;
            int b = a + 3;
            Assert.Equal(8, b);
        }

        [UnitTest]
        public void int_const_var()
        {
            int a = 5;
            int b = 3 + a;
            Assert.Equal(8, b);
        }
    }
}

```
