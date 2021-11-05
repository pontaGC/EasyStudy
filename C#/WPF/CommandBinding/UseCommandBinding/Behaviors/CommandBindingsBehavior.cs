using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Microsoft.Xaml.Behaviors;

namespace CommandBindingStudy.Behaviors
{
    internal sealed class CommandBindingsBehavior : Behavior<FrameworkElement>
    {
        #region Properties

        public static readonly DependencyProperty CommandBindingsProperty =
            DependencyProperty.Register(nameof(CommandBindings),
                                        typeof(ObservableCollection<CommandBinding>),
                                        typeof(CommandBindingsBehavior),
                                        new PropertyMetadata(null, OnCommandBindingsChanged));

        /// <summary>
        /// Gets or sets a collection of <see cref="CommandBinding"/>.
        /// </summary>
        public ObservableCollection<CommandBinding> CommandBindings
        {
            get => (ObservableCollection<CommandBinding>)this.GetValue(CommandBindingsProperty);
            set => this.SetValue(CommandBindingsProperty, value);
        }

        #endregion

        #region Attach & Detach

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.CommandBindings.Clear();
        }

        #endregion

        #region Methods

        private static void OnCommandBindingsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is CommandBindingsBehavior thisBehavior))
            {
                return;
            }
            
            if (e.OldValue is ObservableCollection<CommandBinding> oldBidnings)
            {
                oldBidnings.CollectionChanged -= thisBehavior.OnCommandBindingsCollectionChanged;
            }


            if (e.NewValue is ObservableCollection<CommandBinding> newBindings)
            {
                newBindings.CollectionChanged += thisBehavior.OnCommandBindingsCollectionChanged;
            }

            thisBehavior.UpdateCommandBindings();
        }

        private void OnCommandBindingsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (AssociatedObject == null || this.CommandBindings == null)
            {
                return;
            }

            AssociatedObject.CommandBindings.Clear();
            AssociatedObject.CommandBindings.AddRange(this.CommandBindings);
            CommandManager.InvalidateRequerySuggested();
        }

        private void UpdateCommandBindings()
        {
            AssociatedObject.CommandBindings.Clear();
            if (this.CommandBindings != null)
            {
                AssociatedObject.CommandBindings.AddRange(this.CommandBindings);
                CommandManager.InvalidateRequerySuggested();
            }
        }

        #endregion

    }
}
