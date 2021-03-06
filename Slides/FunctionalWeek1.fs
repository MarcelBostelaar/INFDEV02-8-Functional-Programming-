﻿module FunctionalWeek1

open CommonLatex
open LatexDefinition
open CodeDefinitionLambda
open Interpreter

let LambdaStateTrace(x,y,z) = LambdaStateTrace(x,y,z,true,true,true,true,true,true)
let LambdaCodeBlock(x,y) = LambdaCodeBlock(x,y,false)

let slides =
  [
    Section("Introduction")
    SubSection("Course introduction")
    ItemsBlock
      [
        !"Course topic: what is this course about?"
        !"Examination: how will you be tested?"
        !"Start with course"
      ]

    SubSection("Course topic: functional programming")
    ItemsBlock
      [
        !"Lambda calculus"
        !"From lambda calculus to functional programming"
        !"Functional programming using \Fsharp\ and Haskell"
      ]

    SubSection("Advantages of functional programming")
    ItemsBlock
      [
        !"Strong mathematical foundations"
        !"Easier to reason about programs"
        !"Parallelism for ``free''"
        !"Correctness guarantees through strong typing (optional)"
      ]    

    SubSection("Examination")
    ItemsBlock
      [
        !"Theory exam: test understanding of theory"
        !"Practical exam: test ability to apply theory in practice"
      ]

    SubSection("Theory exam: reduction and typing")
    ItemsBlock
      [
        !"One question on reduction in lambda calculus"
        ! @"One question on typing in lambda calculus, \Fsharp, or Haskell"
        ! @"\textbf{Passing grade} if both questions answered correctly"
      ]

    SubSection("Practical exam: interpreter for a virtual machine")
    ItemsBlock
      [
        !"In a group, build an interpreter for a virtual machine"
        !"According to a specification that will be provided"
        !"Groups may consist of up to 4 students"
        !"Understanding of code tested \\textbf{individually}"
      ]
      
    SubSection("Lecture topics")
    ItemsBlock
      [
        ! "Semantics(meaning) of imperative languages"
        ! "Lambda calculus, the foundation for functional languages"
      ]

    Section("Semantics of imperative languages")
    SubSection("Imperative program: sequence of statements")
    ItemsBlock //WithTitle "Imperative program: sequence of statements"
      [
        !"Statements directly depend on and alter memory"
        !"Meaning of statements may depend on contents of memory"
        !"Any statement may depend on (read) any memory location"
        !"Any statement may alter any memory location"
      ]

    VerticalStack
      [
        ItemsBlockWithTitle "Example: meaning of statement sequence"
          [
            !"Statement $s_1$ changes the machine state from $S_0$ to $S_1$"
            !"Statement $s_2$ changes the machine state from $S_1$ to $S_2$"
           // !"$(S_0 \stackrel{s_1}{\longmapsto} S_1) \wedge (S_1 \stackrel{s_2}{\longmapsto} S_2) \implies S_0 \stackrel{s_1 s_2}{\longmapsto} S_2$"
            !"Run statement $s_1$, then run statement $s_2$: $s_1 s_2$"
            !"Statement $s_1 s_2$ changes the machine state from $S_0$ to $S_2$"
            
          ]
        !"\centering$(S_0 \stackrel{s_1}{\longmapsto} S_1) \wedge (S_1 \stackrel{s_2}{\longmapsto} S_2) \implies S_0 \stackrel{s_1 s_2}{\longmapsto} S_2$"
 (*       TypingRules
          [
            {
              Premises = [ @"S_0 \stackrel{s_1}{\longmapsto} S_1\quad S_1 \stackrel{s_2}{\longmapsto} S_2" ]
              Conclusion = @"S_0 \stackrel{s_1 s_2}{\longmapsto} S_2"
            }
          ]*)
        Pause
        Question "What about $s_2 s_1$?"

      ]

    VerticalStack
      [
        ItemsBlockWithTitle "Swap order of $s_1 s_2$: $s_2 s_1$"
          [
            !"Sometimes $s_2 s_1$ has the same meaning as $s_1 s_2$\ldots"
            !"Sometimes $s_2 s_1$ is completely different from $s_1 s_2$!"
            !"It depends on $s_1$, $s_2$, and the relevant machine state $S_0$"
            !"It depends on implementation details of $s_1$ and $s_2$"
            !"Implementation details matter $\implies$ leaky abstraction!"
            //!"Often it is impossible to determine because of the implicit dependence via the machine state"
          ]
        Pause
        Question "Can we do better?"
      ]

    VerticalStack
      [
        ItemsBlockWithTitle "Idea for better abstraction: remove implicit dependencies"
          [
            ! @"No implicit dependencies $\implies$ all dependencies explicit"
            !"No access to arbitrary machine state"
            !"Only explicitly-mentioned state may be accessed"
          ]
        Pause
        Question "What if $s_1$ and $s_2$ access the same state?"
      ]

    VerticalStack
      [
        ItemsBlockWithTitle "What if $s_1{\{x\}}$ and $s_2{\{x\}}$ only read the same state $x$?"
          [
            ! @"$s_1{\{x\}}$ calculates $x+x$, and $s_2{\{x\}}$ calculates the square $x^2$"
          ]
        Question "Can we reorder $s_1{\{x\}}$ and $s_2{\{x\}}$?"
        Pause
        ItemsBlockWithTitle "What if $s_1{\{x\}}$ and $s_2{\{x\}}$ alter the same state $x$?"
          [
            ! @"$s_1{\{x\}}$ sets $x$ to 1, and $s_2{\{x\}}$ sets $x$ to 2"
          ]
        Question "Can we reorder $s_1{\{x\}}$ and $s_2{\{x\}}$?"
        Pause
        Question "Can we do better?"
      ]

    VerticalStack
      [
        ItemsBlockWithTitle "Idea for better abstraction: remove implicit dependencies"
          [
            ! @"No implicit dependencies $\implies$ all dependencies explicit"
            !"No reading of arbitrary machine state"
            !"No mutating of arbitrary machine state"
            !"Only explicitly-mentioned machine state may be read"
          ]
        Pause
        Block !"NB: No provision at all is made for mutating machine state"
        ]

    VerticalStack
      [
        ItemsBlockWithTitle "Wait a minute, this is just like functions"
          [
            !"Not statements, but (mathematical) functions"
            !"Functions depend only on arguments"
            !"Functions do not mutate machine state"
            !"Can calculate function value when all arguments are known"
            !"Can always replace a function call by its value"
          ]
        Pause
        BlockWithTitle("NB: Imperative ``functions'' need not be functions!", !"Non-function ``functions'' are more properly called procedures")
       ]

    VerticalStack
      [
        BlockWithTitle(@"\textbf{Referential transparency:}", !"It is always valid to replace a function call by its value")
        
        Pause
        BlockWithTitle("Advanced topic:", !"Allow mutation of state without losing referential transparency")
      ]

    Section "Lambda calculus"
    SubSection "Introduction to Lambda Calculus"
    VerticalStack
      [
        ItemsBlockWithTitle "What is lambda calculus?"
          [
            !"Model of computation based on functions"
            !"Completely different from Turing machines, but equivalent"
            !"Foundation of all functional programming languages"
            !"Truly tiny when compared with its power"
            !"Consists of only (function) abstraction and application"
          ]
      ]

    SubSection "Grammar"
    VerticalStack
      [
        ItemsBlockWithTitle "A lambda calculus term is one of three things:"
          [
            !"a variable (from some arbitrary infinite set of variables)"
            !"an abstraction (a ``function of one variable'')"
            !"an application (a ``function call'')"
          ]
      ]

    VerticalStack
      [
        BlockWithTitle("Variables (arbitrary infinite set):",! @"$a, b, c, \ldots\hfil a_0, a_1, \ldots\hfil b_0, b_1, \ldots$")
        BlockWithTitle("Abstractions:",! @"For any variable $x$ and lambda term $T$: $(\lambda x.T)$")
        BlockWithTitle("Applications:",! @"For any lambda terms $F$ and $T$: $(FT)$")
      ]

    VerticalStack
      [
        TextBlock "A simple example: the identity function (just returns its input)"

        LambdaCodeBlock(TextSize.Small, -"x" ==> !!"x")
      ]

    VerticalStack
      [
        TextBlock "A simple example: call the identity function on a variable"

        LambdaCodeBlock(TextSize.Small, (-"x" ==> !!"x") >> !!"v")
      ]

    SubSection "Beta reduction"
    VerticalStack
      [
        ItemsBlockWithTitle @"$\beta$-reduction"
          [
            !"Redex: application of an abstraction to an argument"
            !"Result: in abstraction body replace parameter by argument"
           ]
        ! @"\centering$((\lambda x.B)A) \rightarrow_\beta B [ x \mapsto A ]$"
      ]

//    LambdaStateTrace(TextSize.Small, (-"x" ==> !!"x") >> !!"v", Option.None)

    SubSection "Multiple parameters"
    VerticalStack
      [
        BlockWithTitle("Multiple parameters via nested abstractions:",! @"(\lambda x.(\lambda y.(x y)))")

//        LambdaCodeBlock(TextSize.Small, -"x" ==> (-"y" ==> (!!"x" >> !!"y")))

        TextBlock "The parameters are then given one at a time:"

        LambdaCodeBlock(TextSize.Small, ((-"x" ==> (-"y" ==> (!!"x" >> !!"y"))) >> !!"A") >> !!"B")
      ]

    LambdaStateTrace(TextSize.Small, ((-"x" ==> (-"y" ==> (!!"x" >> !!"y"))) >> !!"A") >> !!"B", Option.None)

    Section "Closing up"
    SubSection "Example executions of (apparently) nonsensical programs"
    ItemsBlock
      [
        ! @"Manual execution of various lambda programs."
        ! @"Try to work out the result of these programs."
      ]

    VerticalStack
      [
        Question "What is the result of this program?"

        LambdaCodeBlock(TextSize.Small, ((-"x" ==> (-"y" ==> (!!"x" >> !!"y")) >> (-"z" ==> (!!"z" >> !!"z"))) >> !!"A"))
      ]

    LambdaStateTrace(TextSize.Small, ((-"x" ==> (-"y" ==> (!!"x" >> !!"y")) >> (-"z" ==> (!!"z" >> !!"z"))) >> !!"A"), Option.None)

    VerticalStack
      [
        Question "What is this program's result? Hint: scope!"

        LambdaCodeBlock(TextSize.Small, (-"x" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B")
      ]

    LambdaStateTrace(TextSize.Small, (-"x" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B", Option.None)

    VerticalStack
      [
        TextBlock "Outer $x$ is shadowed by inner $x$!"

        LambdaCodeBlock(TextSize.Small, (-"x" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B")
      ]

    VerticalStack
      [
        TextBlock "To disambiguate, turn:"

        LambdaCodeBlock(TextSize.Small, (-"x" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B")

        TextBlock "into:"

        LambdaCodeBlock(TextSize.Small, (-"y" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B")
      ]

    LambdaStateTrace(TextSize.Small, (-"y" ==> (-"x" ==> (!!"x" >> !!"x")) >> !!"A") >> !!"B", Option.None)


    VerticalStack
      [
        Question "What is this program's result? Is there even one?"

        LambdaCodeBlock(TextSize.Small, (-"x" ==> (!!"x" >> !!"x")) >> (-"x" ==> (!!"x" >> !!"x")))
      ]

    LambdaStateTrace(TextSize.Small, (-"x" ==> (!!"x" >> !!"x")) >> (-"x" ==> (!!"x" >> !!"x")), Some 2)

    VerticalStack
      [
        LambdaCodeBlock(TextSize.Small, (-"x" ==> (!!"x" >> !!"x")) >> (-"x" ==> (!!"x" >> !!"x")))

        TextBlock @"It never ends! Like a \texttt{while true: ..}!"
      ]

    SubSection "Crazy teachers tormenting poor students, or ``where are my integers?''"
    VerticalStack
      [
        BlockWithTitle("What you are all thinking:",!"This is no real programming language!")

        ItemsBlockWithTitle("Is this a joke?")
          [
            ! "We have some sort of functions and function calls"
            ! @"We do not have booleans and \textttt{if}'s"
            ! @"We do not have integers and arithmetic operators"
            ! @"We do not have a lot of things!"
          ]

        Pause
        BlockWithTitle("Surprise!",! "All these things are in there awaiting discovery!")
        Pause
        BlockWithTitle("Stay tuned",! "This will be a marvelous voyage!")
      ]
  ]

