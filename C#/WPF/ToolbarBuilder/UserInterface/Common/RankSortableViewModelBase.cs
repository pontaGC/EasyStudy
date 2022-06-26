using Prism.Mvvm;

using System;

namespace ToolbarBuilder.UserInterface.Common
{
    /// <summary>
    /// The view-model can be sorted by <c>Rank</c> property.
    /// </summary>
    internal abstract class RankSortableViewModelBase : BindableBase, IComparable<RankSortableViewModelBase>
    {
        #region Fields

        private int rank;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the priority for the order of menu item.
        /// </summary>
        public int Rank
        {
            get => this.rank;
            set => this.SetProperty(ref this.rank, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares this instance by <c>Rank</c> and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">The instance to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance.</returns>
        public int CompareTo(RankSortableViewModelBase other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            return this.rank.CompareTo(other.rank);
        }

        #endregion

        #region Relational operators

        public static bool operator >(RankSortableViewModelBase left, RankSortableViewModelBase right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator <(RankSortableViewModelBase left, RankSortableViewModelBase right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator >=(RankSortableViewModelBase left, RankSortableViewModelBase right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(RankSortableViewModelBase left, RankSortableViewModelBase right)
        {
            return left.CompareTo(right) <= 0;
        }

        #endregion
    }
}
