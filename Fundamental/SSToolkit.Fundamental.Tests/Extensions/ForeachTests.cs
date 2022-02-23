﻿namespace SSToolkit.Fundamental.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class ForEachTests
    {
        [Fact]
        public void ForEach_Test()
        {
            var resultList = new List<string>();
            var list = new List<string>()
            {
                "item1",
                "item2",
                "item3"
            };
            
            list.AsEnumerable().ForEach(item =>
            {
                resultList.Add(item);
            });

            resultList.Count.ShouldBe(3);
            resultList.ShouldBe(list);

            resultList = new List<string>();
            (list as ICollection<string>).ForEach(item =>
            {
                resultList.Add(item);
            });

            resultList.Count.ShouldBe(3);
            resultList.ShouldBe(list);

            resultList = new List<string>();
            (list as IReadOnlyCollection<string>).ForEach(item =>
            {
                resultList.Add(item);
            });

            resultList.Count.ShouldBe(3);
            resultList.ShouldBe(list);
        }
    }
}