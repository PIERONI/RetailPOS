using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace RetailPOS.Utility
{
    public enum Mask
    {
        IsString,
        IsAlphaNumeric,
        IsStringSpace,
        IsStringSpaceNum,
        IsNumeric,
        IsDecimal,
        IsSpaceNotAllow,
        IsAlphaNumerichyphen,
        IsEmailAllow

    }

    public static class MaskedTextBoxBehaviour
    {
        /// <summary>
        /// TextBox Attached Dependency Property for string
        /// </summary>
        public static readonly DependencyProperty IsStringOnlyProperty = DependencyProperty.RegisterAttached(
           Mask.IsString.ToString(),
           typeof(bool),
           typeof(MaskedTextBoxBehaviour),
           new UIPropertyMetadata(false, OnIsStringOnlyChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For Alphanumeric
        /// </summary>
        public static readonly DependencyProperty IsAlphaNumeric = DependencyProperty.RegisterAttached(
        Mask.IsAlphaNumeric.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsAlphaNumericChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For String Space
        /// </summary>
        public static readonly DependencyProperty IsStringSpace = DependencyProperty.RegisterAttached(
        Mask.IsStringSpace.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsStringOnlyChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For String Space with num
        /// </summary>
        public static readonly DependencyProperty IsStringSpaceNumber = DependencyProperty.RegisterAttached(
        Mask.IsStringSpaceNum.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsStringSpaceNumberChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For Numbers only 
        /// </summary>
        public static readonly DependencyProperty IsNumeric = DependencyProperty.RegisterAttached(
        Mask.IsNumeric.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsNumericChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For Decimal only 
        /// </summary>
        public static readonly DependencyProperty IsDecimal = DependencyProperty.RegisterAttached(
        Mask.IsDecimal.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsDecimalChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For Decimal only 
        /// </summary>
        public static readonly DependencyProperty IsSpaceNotAllow = DependencyProperty.RegisterAttached(
        Mask.IsSpaceNotAllow.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsSpaceChanged));

        /// <summary>
        /// TextBox Attached Dependency Property For Alpha numeric and hyphen  only 
        /// </summary>
        public static readonly DependencyProperty IsAlphaNumerichyphen = DependencyProperty.RegisterAttached(
        Mask.IsAlphaNumerichyphen.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsAlphaNumerichyphenChanged));

        /// <summary>
        /// The is email allow
        /// </summary>
        public static readonly DependencyProperty IsEmailAllow = DependencyProperty.RegisterAttached(
        Mask.IsEmailAllow.ToString(),
        typeof(bool),
        typeof(MaskedTextBoxBehaviour),
        new UIPropertyMetadata(false, OnIsEmailChanged));

        #region Is EmailOnly
        public static bool GetIsEmailOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsEmailAllow);
        }
        public static void SetIsEmailOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsEmailAllow, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsEmailChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += AllowIsEmailOnly;
                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= AllowIsEmailOnly;
                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }

        private static void AllowIsEmailOnly(object sender, TextCompositionEventArgs e)
        {
            if (Regex.Match(e.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                e.Handled = true;
        }
        #endregion

        #region IsAlphanumeric Hypen
        public static bool GetIsAlphaNumerichyphenOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsAlphaNumerichyphen);
        }
        public static void SetIsAlphaNumerichyphenOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsAlphaNumerichyphen, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsAlphaNumerichyphenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += AllowIsAlphaNumerichyphenOnly;
                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= AllowIsAlphaNumerichyphenOnly;
                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }

        private static void AllowIsAlphaNumerichyphenOnly(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(e.Text, @"[a-zA-Z0-9\-]+").Success)
                e.Handled = true;
        }
        #endregion

        #region IsSpaceNotAllow Only
        public static bool GetIsSpaceNotAllow(DependencyObject d)
        {
            return (bool)d.GetValue(IsSpaceNotAllow);
        }
        public static void SetIsSpaceNotAllow(DependencyObject d, bool value)
        {
            d.SetValue(IsSpaceNotAllow, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsSpaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {

                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {

                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }


        #endregion

        #region IsDecimal Only
        public static bool GetIsDecimalOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsDecimal);
        }
        public static void SetIsDecimalOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsDecimal, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsDecimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += AllowDecimalOnly;
                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= AllowDecimalOnly;
                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }

        private static void AllowDecimalOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        #endregion

        #region IsNumeric Only
        public static bool GetIsNumericOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsNumeric);
        }
        public static void SetIsNumericOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsNumeric, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsNumericChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += AllowNumOnly;
                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= AllowNumOnly;
                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }

        private static void AllowNumOnly(object sender, TextCompositionEventArgs e)
        {

            foreach (char ch in e.Text)
            {

                if (!Char.IsDigit(ch))
                {
                    e.Handled = true;
                }

            }
        }

        #endregion

        #region IsSpaceWithString
        public static bool GetIsStringSpacOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsStringSpace);
        }

        public static void SetIsStringSpacOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsStringSpace, value);
        }
        #endregion

        #region IsSpaceWithStringNum
        public static bool GetIsStringSpaceNumOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsStringSpaceNumber);
        }
        public static void SetIsStringSpaceNumOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsStringSpaceNumber, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsStringSpaceNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += SpeicalChar;

            }
            else
            {
                textBox.PreviewTextInput -= SpeicalChar;

            }
        }

        private static void SpeicalChar(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(e.Text, @"^[a-zA-Z0-9]$").Success)
                e.Handled = true;
        }

        #endregion

        #region IsAlphanumeric

        public static bool GetIsAlphaNumericOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsAlphaNumeric);
        }
        public static void SetIsAlphaNumericOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsAlphaNumeric, value);
        }

        /// <summary>
        /// Handles changes to the OnIsAlphaNumericChanged property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsAlphaNumericChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += BlockSpeicalChar;
                textBox.PreviewKeyDown += ReviewKeyDown;
            }
            else
            {
                textBox.PreviewTextInput -= BlockSpeicalChar;
                textBox.PreviewKeyDown -= ReviewKeyDown;
            }
        }

        /// <summary>
        /// Blocks the speical char.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private static void BlockSpeicalChar(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {

                if (!Char.IsLetterOrDigit(ch))
                {
                    e.Handled = true;
                }

            }
        }
        #endregion

        #region IsString
        /// <summary>
        /// Gets the is string only.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public static bool GetIsStringOnly(DependencyObject d)
        {
            return (bool)d.GetValue(IsStringOnlyProperty);
        }

        /// <summary>
        /// Sets the is string only.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsStringOnly(DependencyObject d, bool value)
        {
            d.SetValue(IsStringOnlyProperty, value);
        }

        /// <summary>
        /// Handles changes to the IsNumericOnly property.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnIsStringOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool IsString = (bool)e.NewValue;

            TextBox textBox = (TextBox)d;

            if (IsString)
            {
                textBox.PreviewTextInput += BlockDigitCharacters;
                if (!e.Property.Name.ToString().Contains("IsStringSpace"))
                {
                    textBox.PreviewKeyDown += ReviewKeyDown;
                }
                else
                {
                    textBox.PreviewKeyDown += ReviewKeyDownSpace;
                }
            }
            else
            {
                textBox.PreviewTextInput -= BlockDigitCharacters;
                if (!e.Property.Name.ToString().Contains("IsStringSpace"))
                {
                    textBox.PreviewKeyDown -= ReviewKeyDown;
                }
                else
                {
                    textBox.PreviewKeyDown -= ReviewKeyDownSpace;
                }
            }
        }


        /// <summary>
        /// Disallows non-digit character.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="TextCompositionEventArgs"/> that contains the event data.</param>
        private static void BlockDigitCharacters(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {
                if (!Char.IsLetter(ch))
                {
                    e.Handled = true;
                }
            }

        }
        #endregion

        /// <summary>
        /// Disallows a space key.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="KeyEventArgs"/> that contains the event data.</param>
        private static void ReviewKeyDownSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                // Disallow the space key, which doesn't raise a PreviewTextInput event.
                e.Handled = false;
            }
        }

        /// <summary>
        /// Disallows a space key.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="KeyEventArgs"/> that contains the event data.</param>
        private static void ReviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                // Disallow the space key, which doesn't raise a PreviewTextInput event.
                e.Handled = true;
            }


        }
    }
}
