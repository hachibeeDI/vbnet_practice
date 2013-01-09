'
' Written by : OGURA_Daiki
'    Date    : 2012-10-30
'   Remarks  :
'
Option Strict On
Option Infer On
Option Explicit On

Namespace Helper

    Public Class Functional

        Public Shared Function _
        f_partial(Of T1, TResult)(f As Func(Of T1, TResult), p1 As T1) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1)
                   End Function
        End Function

        Public Shared Function _
        f_partial(Of T1, T2, TResult)(f As Func(Of T1, T2, TResult), p1 As T1, p2 As T2) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1, p2)
                   End Function
        End Function

        Public Shared Function _
        f_partial(Of T1, T2, T3, TResult)(f As Func(Of T1, T2, T3, TResult), p1 As T1, p2 As T2, p3 As T3) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1, p2, p3)
                   End Function
        End Function

        Public Shared Function _
        f_partial(Of T1, T2, T3, T4, TResult)(f As Func(Of T1, T2, T3, T4, TResult), p1 As T1, p2 As T2, p3 As T3, p4 As T4) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1, p2, p3, p4)
                   End Function
        End Function

        Public Shared Function _
        f_partial(Of T1, T2, T3, T4, T5, TResult)(f As Func(Of T1, T2, T3, T4, T5, TResult), p1 As T1, p2 As T2, p3 As T3, p4 As T4, p5 As T5) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1, p2, p3, p4, p5)
                   End Function
        End Function

        Public Shared Function _
        f_partial(Of T1, T2, T3, T4, T5, T6, TResult)(f As Func(Of T1, T2, T3, T4, T5, T6, TResult), p1 As T1, p2 As T2, p3 As T3, p4 As T4, p5 As T5, p6 As T6) _
        As Func(Of TResult)

            Return Function()
                       Return f(p1, p2, p3, p4, p5, p6)
                   End Function
        End Function

    End Class

End Namespace