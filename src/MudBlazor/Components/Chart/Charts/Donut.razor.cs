﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using MudBlazor.Charts.SVG.Models;

namespace MudBlazor.Charts
{
    public class DonutBase : MudChartBase
    {
        [CascadingParameter] public MudChart MudChartParent { get; set; }

        public List<SvgCircle> Circles = new List<SvgCircle>();
        public List<SvgLegend> Legends = new List<SvgLegend>();

        protected override void OnInitialized()
        {
            double counterClockwiseOffset = 25;
            double totalPercent = 0;
            double offset = counterClockwiseOffset;

            int counter = 0;
            foreach (double data in InputData)
            {
                double percent = data;
                double reversePercent = 100 - percent;
                offset = 100 - totalPercent + counterClockwiseOffset;
                totalPercent = totalPercent + percent;

                var circle = new SvgCircle()
                {
                    Index = counter,
                    CX = 21,
                    CY = 21,
                    Radius = 15.915,
                    StrokeDashArray = $"{percent.ToString(CultureInfo.InvariantCulture)} {reversePercent.ToString(CultureInfo.InvariantCulture)}",
                    StrokeDashOffset = offset
                };
                Circles.Add(circle);


                string labels = "";
                if (counter < InputLabels.Length)
                {
                    labels = InputLabels[counter];
                }
                SvgLegend Legend = new SvgLegend()
                {
                    Index = counter,
                    Labels = labels,
                    Data = data.ToString()
                };
                Legends.Add(Legend);

                counter += 1;
            }
        }
    }
}
