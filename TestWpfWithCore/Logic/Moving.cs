﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TestWpfWithCore.Logic
{
    internal class Moving
    {
        
        Dispatcher dispatcher;
        Random random;
        public static int y = 10;
        public static int x = 10;

        public Moving(Dispatcher dispatcher)
        { 
            
            this.dispatcher = dispatcher;
        }

        Thread second_Button_Move;
        //            В данном коде был добавлен асинхронный метод Move_Logic(), который выполняет передвижение кнопки.
        //            Данный метод возвращает объект Task, который будет использоваться в методе Move() для выполнения асинхронной операции.
        //            В методе Move() используется ключевое слово async для указания того, что данный метод является асинхронным, 
        //            и вызывается метод Move_Logic() с помощью await.

        //            Также добавлен метод Cancel(), который используется для отмены выполнения асинхронной операции.В данном случае он вызывает метод Cancel() у объекта 
        //            CancellationTokenSource.

        //            Обновление свойства Margin кнопки теперь выполняется с помощью метода InvokeAsync() у объекта Dispatcher, 
        //            что позволяет использовать Async/await для более удобного управления асинхронными операциями.
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public async void Move(Button button1)
        {
            try
            {
                
                
                await Move_Logic(tokenSource.Token, button1);
            }
            catch (OperationCanceledException)
            {
                // Обрабатываем отмену операции, если была вызвана методом Cancel()
            }
        }

        public void Cancel()
        {
            tokenSource.Cancel();
            //tokenSource.Dispose();
        }

        private Task Move_Logic(CancellationToken cancellationToken, Button button1)
        {
            random = new Random();
            return Task.Run(async () =>
            {
                //int j = 0;
                //for (int i = 0; i < 10; i++, j++)
                //{
                //    // Обновляем свойство Margin у кнопки с помощью Dispatcher
                //    await dispatcher.InvokeAsync(() =>
                //    {
                //        button1.Margin = new Thickness(x, y, 0, 0);
                //    });

                //    // Увеличиваем координаты x и y на определенный шаг
                //    x += 4;
                //    y += 6;

                //    // Приостанавливаем выполнение асинхронной операции на 50 миллисекунд
                //    await Task.Delay(50, cancellationToken);

                //}
                for (int i = 0; i < 10; i++)
                {
                    // Обновляем свойство Margin у кнопки с помощью Dispatcher
                    await dispatcher.InvokeAsync(() =>
                    {
                        button1.Margin = new Thickness(x, y, 0, 0);
                    });

                    // Увеличиваем координаты x и y на определенный шаг
                    x = random.Next(10, 600);
                    y = random.Next(10, 150);

                    // Приостанавливаем выполнение асинхронной операции на 50 миллисекунд
                    await Task.Delay(50, cancellationToken);
                }
            }, cancellationToken);
        }
    }
}

