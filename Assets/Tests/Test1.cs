using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

[TestFixture]
public class Test1
{

      [Test]
      public void OnTick_Whencalledreturnposition()
      {
            //arrnage
            var position = new List<Vector3>();
            //act
            
            //assert
            Assert.That(position,Is.Not.Null);
            
      }
}
