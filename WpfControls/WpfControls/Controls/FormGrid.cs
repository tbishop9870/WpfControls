using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfControls.Controls
{
    [ContentProperty("Rows")]
    public class FormGrid : Grid, IEnumerable<FormRow>
    {
        private FormRowCollection _rows = new FormRowCollection();

        public FormGrid()
        {
            Rows.RowAdded += InternalAdd;
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
        }

        public FormRowCollection Rows { get; } = new FormRowCollection();

        public void AddChild(object child)
        {
            InternalAdd(child as FormRow);
        }

        public void Add(FormRow row)
        {
            InternalAdd(row);
        }

        private void InternalAdd(FormRow row)
        {
            if (row == null) return;
            var index = RowDefinitions.Count;
            var label = new TextBlock
            {
                Text = row.Header
            };
            SetRow(label, index);
            var content = row.Content;
            SetRow(content, index);
            SetColumn(content, 1);

            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Children.Add(label);
            Children.Add(content);
        }

        public IEnumerator<FormRow> GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FormRowCollection : IList<FormRow>, ICollection<FormRow>, IEnumerable<FormRow>, IList, ICollection, IEnumerable
    {
        private readonly List<FormRow> _backingMember = new List<FormRow>();

        public event Action<FormRow> RowAdded;

        public IEnumerator<FormRow> GetEnumerator()
        {
            return _backingMember.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(FormRow item)
        {
            _backingMember.Add(item);
            OnRowAdded(item);
        }

        public int Add(object value)
        {
            if (!(value is FormRow)) return 0;
            Add((FormRow)value);
            return 1;
        }

        public bool Contains(object value)
        {
            if (!(value is FormRow)) return false;

            return _backingMember.Contains((FormRow)value);
        }

        void IList.Clear()
        {
            _backingMember.Clear();
        }

        public int IndexOf(object value)
        {
            return value is FormRow ? _backingMember.IndexOf((FormRow)value) : -1;
        }

        public void Insert(int index, object value)
        {
            if (!(value is FormRow)) return;
            _backingMember.Insert(index, (FormRow)value);
        }

        public void Remove(object value)
        {
            if (!(value is FormRow)) return;

            _backingMember.Remove((FormRow)value);
        }

        void IList.RemoveAt(int index)
        {
            _backingMember.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get { return _backingMember[index]; }
            set
            {
                if (!(value is FormRow)) return;
                _backingMember[index] = (FormRow)value;
            }
        }

        bool IList.IsReadOnly => false;
        public bool IsFixedSize => false;

        void ICollection<FormRow>.Clear()
        {
            _backingMember.Clear();
        }

        public bool Contains(FormRow item)
        {
            return _backingMember.Contains(item);
        }

        public void CopyTo(FormRow[] array, int arrayIndex)
        {
            _backingMember.CopyTo(array, arrayIndex);
        }

        public bool Remove(FormRow item)
        {
            return _backingMember.Remove(item);
        }

        public void CopyTo(Array array, int index)
        {
        }

        int ICollection.Count => _backingMember.Count;
        public object SyncRoot => new { };
        public bool IsSynchronized => true;
        int ICollection<FormRow>.Count => _backingMember.Count;
        bool ICollection<FormRow>.IsReadOnly => false;
        public int IndexOf(FormRow item)
        {
            return _backingMember.IndexOf(item);
        }

        public void Insert(int index, FormRow item)
        {
            _backingMember.Insert(index, item);
        }

        void IList<FormRow>.RemoveAt(int index)
        {
            _backingMember.RemoveAt(index);
        }

        public FormRow this[int index]
        {
            get { return _backingMember[index]; }
            set { _backingMember[index] = value; }
        }

        protected virtual void OnRowAdded(FormRow obj)
        {
            RowAdded?.Invoke(obj);
        }
    }

    [ContentProperty(nameof(Content))]
    public class FormRow : DependencyObject
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(FormRow), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            "Content", typeof(FrameworkElement), typeof(FormRow), new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement Content
        {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
