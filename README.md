# Paralelní programování v jazyce C#

Soubory obsahují velmi jednoduché demostrace použití některých (nejčastějších) funkcionalit pro paralelní programování v jazyce C#. 

1. Threads.cs - soubor obsahuje základní ukázu vytváření, spuštění a ukončení vláken na příkladu sdíleného čítače.
2. ThreadPool.cs - příklad stejný jako s vlákny, ale za použití pool vláken (recyklace vláken)
3. class-parallel.cs - ukázka použití knihovny TPL a její třídy Parallel(for, foreach, invoke)
4. task.cs - knihovka TPL a třída Task
5. task-factory.cs - spouštění a vytváření přímo několika Task pomocí TaskFactory
6. async-await.cs - příklad na asynchronní promování, použití klíčových slov async a await
7. primitivs.cs - ukázka několika synchronizačních primitiv (lock, mutex, semaphore, ReaderWriterLock)
8. plinq.cs - ukázka základního použití paralelního LINQ
9. plinq-2.cs - další (rozsáhlejší) ukázka PLINQ
10. load-write-async.cs - implementace asynchronní práce se soubory
