using System;
using System.Collections.Generic;

namespace BV.Library {
    public class LRUCache {
        private Dictionary<String, String> cache { get; set; }
        private Dictionary<String, Node> history { get; set; }
        private Int32 size { get; set; }
        private Node newest { get; set; }
        private Node oldest { get; set; }
        public Int32 currentSize { get; set; }

        public LRUCache(Int32 size) {
            if (size <= 0) {
                throw new ArgumentException("cache cannot have negative size");
            }
            this.size = size;
            currentSize = 0;
            cache = new Dictionary<String, String>();
            history = new Dictionary<string, Node>();
        }

        public void set(String key, String value) {

            if (currentSize < size) {
                // we are below the size
                cache[key] = value;

                // updating history
                if (newest == null) {
                    // this is the first element
                    newest = new Node(key);
                    oldest = newest;
                    history[key] = newest;
                    currentSize++;
                } else {
                    if (history.ContainsKey(key)) {
                        moveToFront(key);
                    } else {
                        // is is a new element
                        insertNewElementToFront(key);
                        currentSize++;
                    }

                }
            } else {
                // delete oldest form cache
                cache.Remove(oldest.Key);
                // delete oldest from hisotory
                history.Remove(oldest.Key);
                oldest.Previous.Next = null;
                oldest = oldest.Previous;
                // update cache
                cache[key] = value;
                // update history
                insertNewElementToFront(key);
            }

        }

        public String get(String key) {
            if (cache.ContainsKey(key)) {
                moveToFront(key);
                return cache[key];
            }
            return null;
        }

        private void insertNewElementToFront(String key) {
            var newHead = new Node(key);
            newHead.Next = newest;
            newest.Previous = newHead;
            newest = newHead;
            history[key] = newest;
        }

        private void moveToFront(String key) {
            var node = history[key];
            if (node != newest) {
                // the node is not the newest, so for sure it has a previous
                node.Previous.Next = node.Next;
                if (node.Next == null) {
                    // no next node means this is the last node
                    oldest = node.Previous;
                } else {
                    node.Next.Previous = node.Previous;

                }
                node.Next = newest;
                newest.Previous = node;
                newest = node;
            }
        }

        /// <summary>
        /// The history of the cache will be kept in a doubly linked list
        /// </summary>
        private class Node {
            public string Key { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(String key) {
                Key = key;
            }
        }
    }
}
