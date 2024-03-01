using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Model
{
    internal class Textbox
    {
        // Variables
        private Texture2D _texture;
        private Rectangle _rect;
        private string _text = "";
        private string _etext = "";
        private Keys[] _lastKeys;

        public Textbox(Texture2D texture, Rectangle rect)
        {
            // Variable Constructors 
            _texture = texture;
            _rect = rect;

            _lastKeys = new Keys[0];
        }

        public void Update()
        { 
            // Get the keyboard state and store pressed keys into an array
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (!_lastKeys.Contains(key))
                {
                    // Allows user to use backspace to delete a character
                    if (key == Keys.Back && _text.Length > 0)
                    {
                        _text = _text.Substring(0, _text.Length - 1);
                    }
                    // Allows user to press any alphabetic character into inputt
                    else if (key >= Keys.A && key <= Keys.Z)
                    {
                        _text += key.ToString();
                    }
                    // Creates a space in the output when space is pressed
                    else if (key == Keys.Space)
                    {
                        _text += " ";
                    }
                    // When enter is pressed, send text to the output menu
                    else if (key == Keys.Enter)
                    {
                        _etext = _text;
                        _text = "";
                    }
                }
            }


            _lastKeys = pressedKeys;
        }

        // Draw method for text and textbox
        public void Draw()
        {

            Globals.SpriteBatch.Draw(_texture, _rect, Color.White);
            Globals.SpriteBatch.DrawString(Globals.font, _text, new Vector2(_rect.X + 5, _rect.Y + 5), Color.Black);
            Globals.SpriteBatch.DrawString(Globals.font, _etext, new Vector2(_rect.X + 5, _rect.Y - 50), Color.White);
        }

        // Get method for output text
        public string GetText()
        { 
            return _etext;
        }
        public void setText(String text)
        {
            _etext = text;
        }
    }
}
