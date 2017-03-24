using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode.UnitTest
{
    [TestClass]
    public class _00_UnitTest
    {
        [TestMethod]
        public void _01_TwoSum()
        {
            Solution s = new Solution();
            int[] nums = new int[] { 1, 3, 7, 9, 11 };
            var result = s.TwoSum(nums, 10);
            Assert.IsTrue(result[0] == 1 && result[1] == 2);
        }

        [TestMethod]
        public void _02_AddTwoNumbers()
        {
            var l1 = new ListNode(5);
            l1.next = new ListNode(6);
            var l2 = new ListNode(4);
            l2.next = new ListNode(5);
            var expected = new ListNode(9);
            expected.next = new ListNode(1);
            expected.next.next = new ListNode(1);
            Assert.AreEqual(expected.val, new Solution().AddTwoNumbers(l1, l2).val);
        }

        [TestMethod]
        public void _03_LengthOfLongestSubstring()
        {
            Solution s = new Solution();

            //  Assert.AreEqual(s.LengthOfLongestSubstring("abcabcbb"), 3);
            //   Assert.AreEqual(s.LengthOfLongestSubstring("bbbbbbb"), 1);
            Assert.AreEqual(s.LengthOfLongestSubstring("pwwkew"), 3);
        }


        public class Solution
        {
            #region 01TwoSum
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int num1 = nums[i];
                    int num2 = target - num1;
                    if (map.ContainsKey(num2))
                        return new int[] { map[num2], i };
                    map[num1] = i;
                }
                return null;
            }
            #endregion

            #region 02AddTwoNumbers
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                return SumNode(l1, l2, 0);
            }

            private ListNode SumNode(ListNode l1, ListNode l2, int increase)
            {
                if (l1 == null && l2 == null)
                {
                    return increase == 0 ? null : new ListNode(increase);
                }
                var rootSum = l1.val + l2.val + increase;
                int mod = rootSum % 10;
                int next = rootSum >= 10 ? 1 : 0;
                var result = new ListNode(rootSum % 10);
                result.next = SumNode(l1?.next, l2?.next, next);
                return result;
            }
            #endregion

            #region 03LengthOfLongestSubstring
            public int LengthOfLongestSubstring(string s)
            {
                var charArray = s.ToCharArray();
                Dictionary<char, int> dic = new Dictionary<char, int>();
                int maxCount = 0;
                int index = 0;
                while (index < charArray.Length)
                {
                    var c = charArray[index];
                    if (dic.ContainsKey(c))
                    {
                        maxCount = Math.Max(maxCount, dic.Count);
                        index = dic[c];
                        dic.Clear();
                    }
                    else
                        dic.Add(c, index);
                    index++;
                }
                return Math.Max(maxCount, dic.Count);

            }
            #endregion

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
            }
        }

    }


}
