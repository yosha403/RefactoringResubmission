using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PigLatin
{
    public class TestPigLatin
    {
        [Theory]
        [InlineData("apple", "appleway")]
        [InlineData("heck", "eckhay")]
        [InlineData("strong", "ongstray")]
        [InlineData("tommy@email.com", "tommy@email.com")]
        [InlineData("aardvark", "aardvarkway")]
        [InlineData("Tommy", "ommytay")]
        [InlineData("gym", "gym")]
        [InlineData("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")]

        public void TestTranslate(string input, string expected)
        {
            //Arrange 
            PigLatinTranslator p = new PigLatinTranslator();

            //Act 
            string actual = p.ToPigLatin(input);

            //Assert 
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData('a', true)]
        [InlineData('y', false)]
        [InlineData('t', false)]
        [InlineData('o', true)]
        public void TestIsVowel(char letter, bool expected)
        {
            //Arrange 
            PigLatinTranslator p = new PigLatinTranslator();

            //Act
            bool actual = p.IsVowel(letter);

            //Assert 
            Assert.Equal(expected, actual);
        }
    }
}
