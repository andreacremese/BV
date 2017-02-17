using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BV.Library;

namespace BVC.Library.Test {
    [TestClass]
    public class LruCahceTest {

        [TestMethod]
        public void LRUCache_return_null_for_no_element () {
            // arrange 
            var _sut = new LRUCache(2);
            // act
            var output = _sut.get("somekey");
            // 
            Assert.IsNull(output);
        }

        [TestMethod]
        public void LRUCahce_correctly_returns_on_setting() {
            // arrange
            var _sut = new LRUCache(2);
            var expected_2 = "2";
            var expected_3 = "3";
            _sut.set("first", "1");
            _sut.set("second", expected_2);
            _sut.set("third", expected_3);
            // act and assert
            Assert.IsNull(_sut.get("first"));
            Assert.AreEqual(expected_2, _sut.get("second"));
            Assert.AreEqual(expected_3, _sut.get("third"));
        }

        [TestMethod]
        public void LRUCache_specification() {
            // arrange
            var _sut = new LRUCache(3);
            var foo_1 = "1";
            var foo_2 = "1.1";
            var spam = "2";
            var ham = "third";
            var parrot = "four";
            // act and assert
            Assert.IsNull(_sut.get("foo"));
            _sut.set("foo", foo_1);
            Assert.AreEqual(foo_1,_sut.get("foo"));
            _sut.set("foo", foo_2);
            Assert.AreEqual(foo_2,_sut.get("foo"));
            _sut.set("spam", spam);
            _sut.set("ham", ham);
            _sut.set("parrot", parrot);
            Assert.IsNull(_sut.get("foo")); 
            Assert.AreEqual(spam, _sut.get("spam"));
            Assert.AreEqual(ham, _sut.get("ham"));
            Assert.AreEqual(parrot, _sut.get("parrot"));
        }

        [TestMethod]
        public void LRUCache_get_method_updates_history() {
            // arrange
            var _sut = new LRUCache(2);
            var v1 = "first";
            var v2 = "second";
            var v3 = "third";
            // act
            _sut.set("v1", v1);
            _sut.set("v2", v2);
            var temp = _sut.get("v1");
            _sut.set("v3", v3);
            // assert
            Assert.AreEqual(v1, _sut.get("v1"));
            Assert.IsNull(_sut.get("v2"));
            Assert.AreEqual(v3, _sut.get("v3"));
        }

        [TestMethod]
        public void LRUCache_multiple_sets_before_cache_is_full() {
            // arrange
            var _sut = new LRUCache(2);
            var v1 = "first";
            var v2 = "second";
            var v3 = "third";
            // act
            _sut.set("v1", "throw away 1");
            _sut.set("v1", "throw away 2");
            _sut.set("v1", "throw away 2");
            _sut.set("v1", v1);
            _sut.set("v2", "throw away 3");
            var temp = _sut.get("v1");
            _sut.set("v2", v2);
            _sut.set("v3", v3);
            // assert
            Assert.IsNull(_sut.get("v1"));
            Assert.AreEqual(v2, _sut.get("v2"));
            Assert.AreEqual(v3, _sut.get("v3"));
        }


        [TestMethod]
        public void LRUCache_multiple_gets_before_cache_is_full() {
            // arrange
            var _sut = new LRUCache(2);
            var v1 = "first";
            var v2 = "second";
            var v3 = "third";
            // act
            _sut.set("v1", "throw away");
            var temp = _sut.get("v1");
            temp = _sut.get("v1");
            _sut.set("v1", v1);
            _sut.set("v2", v2);
            temp = _sut.get("v1");
            _sut.set("v3", v3);
            // assert
            Assert.AreEqual(v1, _sut.get("v1"));
            Assert.IsNull(_sut.get("v2"));
            Assert.AreEqual(v3, _sut.get("v3"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "cache cannot have zero or negative size")]
        public void LRUCache_throws_for_negative_size() {
            var _sut = new LRUCache(-1);

        }
    }
}
