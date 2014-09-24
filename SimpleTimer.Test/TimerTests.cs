using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleTimer.Test
{
	[TestClass]
	public class TimerTests
	{
		[TestMethod]
		public void TestDisposeOfTimeout()
		{
			IDisposable disposeHandle = SimpleTimer.SetTimeout(() => Debug.WriteLine("Action Timeout Invoked"), 10000);
			disposeHandle.Dispose();
		}

		[TestMethod]
		public void TestDisposeOfInterval()
		{
			IDisposable disposeHandle = SimpleTimer.SetInterval(() => Debug.WriteLine("Action Interval Invoked"), 10000);
			disposeHandle.Dispose();
		}

		[TestMethod]
		public void TestTimeoutInvoke()
		{
			var test_bool = false;
			IDisposable disposeHandle = SimpleTimer.SetTimeout(() => test_bool = true, 100);
			Assert.IsFalse(test_bool);
			Thread.Sleep(150);
			Assert.IsTrue(test_bool);
		}

		[TestMethod]
		public void TestIntervalInvoke()
		{
			var test_bool = false;
			IDisposable disposeHandle = SimpleTimer.SetInterval(() => test_bool = !test_bool, 100);
			Assert.IsFalse(test_bool);
			Thread.Sleep(150);
			Assert.IsTrue(test_bool);
			Thread.Sleep(100);
			Assert.IsFalse(test_bool);
			Thread.Sleep(100);
			Assert.IsTrue(test_bool);
		}
	}
}
