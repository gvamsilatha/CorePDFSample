#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@PdfSharpCore.com)
//   Klaus Potzesny (mailto:Klaus.Potzesny@PdfSharpCore.com)
//   David Stephensen (mailto:David.Stephensen@PdfSharpCore.com)
//
// Copyright (c) 2001-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.PdfSharpCore.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace MigraDocCore.DocumentObjectModel
{
  /// <summary>
  /// Represents ids for error and diagnostic messages generated by the MigraDoc DOM.
  /// </summary>
  internal enum DomMsgID
  {

    // ----- General Messages ---------------------------------------------------------------------
    StyleExpected,
    BaseStyleRequired,
    EmptyBaseStyle,
    InvalidFieldFormat,
    InvalidInfoFieldName,
    UndefinedBaseStyle,
    InvalidUnitValue,
    InvalidUnitType,
    InvalidEnumForLeftPosition,
    InvalidEnumForTopPosition,
    InvalidColorString,
    InvalidFontSize,
    InsertNullNotAllowed,
    ParentAlreadySet,
    MissingObligatoryProperty,
    InvalidDocumentObjectType,

    // ----- DdlReader Messages -------------------------------------------------------------------

    Success = 1000,

    SymbolExpected,
    SymbolsExpected,
    OperatorExpected,
    KeyWordExpected,
    EndOfFileExpected,
    UnexpectedEndOfFile,

    StyleNameExpected,

    // --- old ---
    //    Internal,

    UnexpectedSymbol,

    IdentifierExpected,
    BoolExpected,
    RealExpected,
    IntegerExpected,
    //    IntegerOrIdentifierExpected,
    StringExpected,
    NullExpected,
    //    SymboleExpected,
    NumberExpected,

    InvalidEnum,
    //    InvalidFlag,
    //    InvalidStyle,
    //    InvalidStyleDefinition,
    InvalidType,
    InvalidAssignment,
    InvalidValueName,
    //    InvalidOperation,
    //    InvalidFormat,
    InvalidRange,
    InvalidColor,
    InvalidFieldType,
    InvalidValueForOperation,
    InvalidSymbolType,

    //    ValueOutOfRange,

    MissingBraceLeft,
    MissingBraceRight,
    MissingBracketLeft,
    MissingBracketRight,
    MissingParenLeft,
    MissingParenRight,
    //    MissingSemicolon,
    MissingComma,

    //    MissingDocumentPart,
    //    MissingEof,
    //    MissingIdentifier,
    //    MissingEndBuildingBlock,
    //    MissingSymbole,
    //    MissingParameter,

    SymbolNotAllowed,
    SymbolIsNotAnObject,
    //    BlockcommentOutsideCodeBlock,
    //    EOFReachedMissingSymbole,
    //    UnexpectedEOFReached,
    //    StyleAlreadyDefined,
    //    MultipleDefaultInSwitch,
    //    UnexpectedNewlineInDirective,
    //    UnexpectedSymboleInDirective,

    //    UnknownUnitOfMeasure,
    //    UnknownValueOperator,
    //    UnknownCodeSymbole,
    //    UnknownScriptSymbole,
    //    UnknownFieldSpecifier,
    //    UnknownFieldOption,
    //    UnknownValueType,
    //    UnknownEvaluationType,
    //    UnknownColorFunction,
    //    UnknownAxis,
    UnknownChartType,

    //    MisplacedCompilerSettings,
    //    MisplacedScopeType,
    //    TooMuchCells,
    NoAccess,

    //    FileNotFound,
    //    NotSupported,

    NewlineInString,
    EscapeSequenceNotAllowed,
    //    SymboleNotAllowedInsideText,
    NullAssignmentNotSupported,
    OutOfRange,

    //    Warning_StyleOverwrittenMoreThanOnce,
    //    Warning_StyleAndBaseStyleAreEqual,
    //    Warning_NestedParagraphInParagraphToken,
    UseOfUndefinedBaseStyle,
    UseOfUndefinedStyle,

    //    NestedFootnote,
    //    ImageInFootnote,
    //    ShapeInFootnote
  }
}
