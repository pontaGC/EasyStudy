using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using ToolbarBuilder.UserInterface.Common;

namespace ToolbarBuilder.UserInterface.Toolbar
{
    internal abstract class ToolBarItemViewModelBase : RankSortableViewModelBase
    {
        #region Fields

        private bool isEnabled;
        private string tooltipText;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBarItemViewModelBase"/> class.
        /// </summary>
        protected ToolBarItemViewModelBase(
            int rank,
            string tooltipKey,
            string tooltipDefaultText)
        {
            this.Rank = rank;
            this.TooltipKey = tooltipKey;
            this.TooltipDefaultText = tooltipDefaultText;
        }

        #endregion

        #region Prooperties

        public string TooltipKey { get; }

        public string TooltipDefaultText { get; }

        /// <summary>
        /// Gets or sets the value indicating the menu item is enable.
        /// </summary>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        public string TooltipText
        {
            get => this.tooltipText;
            set => this.SetProperty(ref this.tooltipText, value);
        }

        #endregion
    }
}
