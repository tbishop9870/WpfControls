using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControls.Controls
{
    /// <summary>
    /// Interaction logic for PlaceholderTextBox.xaml
    /// </summary>
    public partial class PlaceholderTextBox : UserControl
    {
        public PlaceholderTextBox()
        {
            InitializeComponent();
        }

        #region Dependency Properties
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
            "Placeholder", typeof (string), typeof (PlaceholderTextBox), new PropertyMetadata(default(string)));

        public string Placeholder
        {
            get { return (string) GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #region TextBox properties
        public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register(
            "CharacterCasing", typeof (CharacterCasing), typeof (PlaceholderTextBox), new PropertyMetadata(default(CharacterCasing)));

        public CharacterCasing CharacterCasing
        {
            get { return (CharacterCasing) GetValue(CharacterCasingProperty); }
            set { SetValue(CharacterCasingProperty, value); }
        }

        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
            "MaxLength", typeof (int), typeof (PlaceholderTextBox), new PropertyMetadata(default(int)));

        public int MaxLength
        {
            get { return (int) GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.Register(
            "MaxLines", typeof (int), typeof (PlaceholderTextBox), new PropertyMetadata(default(int)));

        public int MaxLines
        {
            get { return (int) GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }

        public static readonly DependencyProperty MinLinesProperty = DependencyProperty.Register(
            "MinLines", typeof (int), typeof (PlaceholderTextBox), new PropertyMetadata(default(int)));

        public int MinLines
        {
            get { return (int) GetValue(MinLinesProperty); }
            set { SetValue(MinLinesProperty, value); }
        }

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(
            "TextAlignment", typeof (TextAlignment), typeof (PlaceholderTextBox), new PropertyMetadata(default(TextAlignment)));

        public TextAlignment TextAlignment
        {
            get { return (TextAlignment) GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextDecorationsProperty = DependencyProperty.Register(
            "TextDecorations", typeof (TextDecorationCollection), typeof (PlaceholderTextBox), new PropertyMetadata(default(TextDecorationCollection)));

        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection) GetValue(TextDecorationsProperty); }
            set { SetValue(TextDecorationsProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (PlaceholderTextBox), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(
            "TextWrapping", typeof (TextWrapping), typeof (PlaceholderTextBox), new PropertyMetadata(default(TextWrapping)));

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping) GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }
        #endregion TextBox properties

        #region TextBoxBase properties

        public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register(
            "AcceptsReturn", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool AcceptsReturn
        {
            get { return (bool) GetValue(AcceptsReturnProperty); }
            set { SetValue(AcceptsReturnProperty, value); }
        }

        public static readonly DependencyProperty AcceptsTabProperty = DependencyProperty.Register(
            "AcceptsTab", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool AcceptsTab
        {
            get { return (bool) GetValue(AcceptsTabProperty); }
            set { SetValue(AcceptsTabProperty, value); }
        }

        public static readonly DependencyProperty AutoWordSelectionProperty = DependencyProperty.Register(
            "AutoWordSelection", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool AutoWordSelection
        {
            get { return (bool) GetValue(AutoWordSelectionProperty); }
            set { SetValue(AutoWordSelectionProperty, value); }
        }

        public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register(
            "CaretBrush", typeof (Brush), typeof (PlaceholderTextBox), new PropertyMetadata(default(Brush)));

        public Brush CaretBrush
        {
            get { return (Brush) GetValue(CaretBrushProperty); }
            set { SetValue(CaretBrushProperty, value); }
        }

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(
            "HorizontalScrollBarVisibility", typeof (ScrollBarVisibility), typeof (PlaceholderTextBox), new PropertyMetadata(default(ScrollBarVisibility)));

        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get { return (ScrollBarVisibility) GetValue(HorizontalScrollBarVisibilityProperty); }
            set { SetValue(HorizontalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty = DependencyProperty.Register(
            "IsInactiveSelectionHighlightEnabled", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsInactiveSelectionHighlightEnabled
        {
            get { return (bool) GetValue(IsInactiveSelectionHighlightEnabledProperty); }
            set { SetValue(IsInactiveSelectionHighlightEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            "IsReadOnly", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsReadOnly
        {
            get { return (bool) GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyCaretVisibleProperty = DependencyProperty.Register(
            "IsReadOnlyCaretVisible", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsReadOnlyCaretVisible
        {
            get { return (bool) GetValue(IsReadOnlyCaretVisibleProperty); }
            set { SetValue(IsReadOnlyCaretVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSelectionActiveProperty = DependencyProperty.Register(
            "IsSelectionActive", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsSelectionActive
        {
            get { return (bool) GetValue(IsSelectionActiveProperty); }
            set { SetValue(IsSelectionActiveProperty, value); }
        }

        public static readonly DependencyProperty IsUndoEnabledProperty = DependencyProperty.Register(
            "IsUndoEnabled", typeof (bool), typeof (PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsUndoEnabled
        {
            get { return (bool) GetValue(IsUndoEnabledProperty); }
            set { SetValue(IsUndoEnabledProperty, value); }
        }

        public static readonly DependencyProperty SelectionBrushProperty = DependencyProperty.Register(
            "SelectionBrush", typeof (Brush), typeof (PlaceholderTextBox), new PropertyMetadata(default(Brush)));

        public Brush SelectionBrush
        {
            get { return (Brush) GetValue(SelectionBrushProperty); }
            set { SetValue(SelectionBrushProperty, value); }
        }

        public static readonly DependencyProperty SelectionOpacityProperty = DependencyProperty.Register(
            "SelectionOpacity", typeof (double), typeof (PlaceholderTextBox), new PropertyMetadata(default(double)));

        public double SelectionOpacity
        {
            get { return (double) GetValue(SelectionOpacityProperty); }
            set { SetValue(SelectionOpacityProperty, value); }
        }

        public static readonly DependencyProperty UndoLimitProperty = DependencyProperty.Register(
            "UndoLimit", typeof (int), typeof (PlaceholderTextBox), new PropertyMetadata(default(int)));

        public int UndoLimit
        {
            get { return (int) GetValue(UndoLimitProperty); }
            set { SetValue(UndoLimitProperty, value); }
        }

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(
            "VerticalScrollBarVisibility", typeof (ScrollBarVisibility), typeof (PlaceholderTextBox), new PropertyMetadata(default(ScrollBarVisibility)));

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility) GetValue(VerticalScrollBarVisibilityProperty); }
            set { SetValue(VerticalScrollBarVisibilityProperty, value); }
        }
        #endregion TextBoxBase properties

        #endregion Dependency Properties

        #region Routed Events
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged",
            RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (PlaceholderTextBox));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value);}
            remove { RemoveHandler(SelectionChangedEvent, value);}
        }

        private void RaiseSelectionChangedEvent()
        {
            RaiseEvent(new RoutedEventArgs(SelectionChangedEvent));
        }

        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent("TextChanged",
            RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (PlaceholderTextBox));

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        private void RaiseTextChangedEvent()
        {
            RaiseEvent(new RoutedEventArgs(TextChangedEvent));
        }
        #endregion Routed Events

        public bool CanRedo => TextBoxBacker.CanRedo;
        public bool CanUndo => TextBoxBacker.CanUndo;
        public double ExtentHeight => TextBoxBacker.ExtentHeight;
        public double ExtentWidth => TextBoxBacker.ExtentWidth;
        public double HorizontalOffset => TextBoxBacker.HorizontalOffset;
        public SpellCheck SpellCheck => TextBoxBacker.SpellCheck;
        public double VerticalOffset => TextBoxBacker.VerticalOffset;
        public double ViewportHeight => TextBoxBacker.ViewportHeight;
        public double ViewportWidth => TextBoxBacker.ViewportWidth;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CaretIndex
        {
            get { return TextBoxBacker.CaretIndex; }
            set { TextBoxBacker.CaretIndex = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LineCount => TextBoxBacker.LineCount;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get { return TextBoxBacker.SelectedText; }
            set { TextBoxBacker.SelectedText = value; }
        }
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get { return TextBoxBacker.SelectionLength; }
            set { TextBoxBacker.SelectionLength = value; }
        }
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart
        {
            get { return TextBoxBacker.SelectionStart; }
            set { TextBoxBacker.SelectionStart = value; }
        }

        public Typography Typography => TextBoxBacker.Typography;


        private void TextBoxBase_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            RaiseSelectionChangedEvent();
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseTextChangedEvent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Text = string.Empty;
        }
    }
}
