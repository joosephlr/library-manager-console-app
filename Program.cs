using LibraryManager.AppConsole;
bool stop = false;

List<Book> books = [];
List<User> users = [];
List<Rent> rents = [];
int contBooks = 1;
int contUsers = 1;
int contRents = 1;

do
{
    string option = "";

    Console.WriteLine("----- Welcome to the Library Manager -----");
    Console.WriteLine("Choose an option below to start using the system:");
    Console.WriteLine("");
    Console.WriteLine("------ Create/Edit/Delete - Books --------");
    Console.WriteLine("1 - Create book");
    Console.WriteLine("2 - Edit book");
    Console.WriteLine("3 - Search for a book");
    Console.WriteLine("4 - List books");
    Console.WriteLine("5 - Delete a book");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("------ Create/Edit/Delete - Users --------");
    Console.WriteLine("6 - Create user");
    Console.WriteLine("7 - Edit user");
    Console.WriteLine("8 - Search for an user");
    Console.WriteLine("9 - List users");
    Console.WriteLine("10 - Delete an user");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("------------------ Rents -----------------");
    Console.WriteLine("11 - Make a rent");
    Console.WriteLine("12 - Return book");
    Console.WriteLine("13 - List rents");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("14 - Leave");
    Console.WriteLine("");
    Console.Write("Type the option's number you desire to choose:");

    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Book book = new();
            
            do
            {
                Console.WriteLine("--------------- Create Book ---------------");

                try
                {
                    Console.WriteLine("Type the book's title:");
                    book.Title = Console.ReadLine();

                    Console.WriteLine("Type the book's author:");
                    book.Author = Console.ReadLine();

                    Console.WriteLine("Type the book's serial number:");
                    book.ISBN = Console.ReadLine();

                    Console.WriteLine("Type the book's year of publish:");
                    book.YearPublish = int.Parse(Console.ReadLine());

                    book.Id = contBooks++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating the book. Error: " + ex.Message);
                }
            } while (book.Id == 0);

            books.Add(book);

            Console.WriteLine("----------- Book created with success ------------");
            break;
        case "2":
            Console.WriteLine("--------------- Edit book ------------------");

            if (books.Count == 0)
            {
                Console.WriteLine("There is no book created!\r\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            }
            
            Book BookEditar = null;
            bool continuarConsultaBookEdicao = true;
            do
            {
                try
                {
                    Console.WriteLine("Type de serial number which you want to consult:");
                    string isbnBookConsultar = Console.ReadLine();
                    BookEditar = books.Find(l => l.ISBN == isbnBookConsultar);

                    if (BookEditar == null)
                    {
                        Console.WriteLine("Book not found, try again! Type S to try again. \r\n");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaBookEdicao = tentarNovamente.ToUpper() == "S";
                    } else
                        continuarConsultaBookEdicao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error editing the book. Error: " + ex.Message);
                }  
            } while (continuarConsultaBookEdicao == true);  

            bool continuarEdicao = true;

            if (BookEditar !=  null && continuarConsultaBookEdicao == false)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Type the new book's name:");
                        BookEditar.Title = Console.ReadLine();

                        Console.WriteLine("Type the new book's author:");
                        BookEditar.Author = Console.ReadLine();

                        Console.WriteLine("Type the new book's serial number:");
                        BookEditar.ISBN = Console.ReadLine();

                        Console.WriteLine("Type the new book's year of publish:");
                        BookEditar.YearPublish = int.Parse(Console.ReadLine());

                        continuarEdicao = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error editing the book. Error: " + ex.Message);
                    }
                } while (continuarEdicao == true);
            }
            
            break;
        case "3":
            Console.WriteLine("--------------- Search for a book ------------------");

            if (books.Count == 0)
            {
                Console.WriteLine("There is no book created!\r\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            }
            
            Book BookConsultar = null;
            bool continuarConsultaBook = true;

            do
            {
                try
                {
                    Console.WriteLine("Type the book's serial number:");
                    string isbnBookConsultar = Console.ReadLine();
                    BookConsultar = books.Find(l => l.ISBN == isbnBookConsultar);

                    if (BookConsultar == null)
                    {
                        Console.WriteLine("Book not found, try again! Type S to try again.");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaBook = tentarNovamente.ToUpper().Equals("S");
                    }else
                        continuarConsultaBook = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error searching the book. Error: " + ex.Message);
                }  
            } while (continuarConsultaBook == true);  

            if( BookConsultar != null)
            {
                BookConsultar.Show();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); 
            }            

            break;       
        case "4":
        // Listar books
            
            Console.WriteLine("------------- Book's list --------------------");

            if (books.Count > 0)
            {
                books.ForEach(l => l.ShowList());
            }
            else
                Console.WriteLine("There is no book created!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;
        case "5":
        // Remover Book
            
            Console.WriteLine("------------- Deleting a book -------------");

            if (books.Count == 0)
            {
                Console.WriteLine("There is no book to delete!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("------------- List books -------------");
            books.ForEach(l => l.ShowList());
            
            Book BookRemover = null;
            bool continuarConsultaBookRemocao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do Book que deseja remover:");
                    int idBookRemover = int.Parse(Console.ReadLine());
                    BookRemover = books.Find(l => l.Id == idBookRemover);

                    if (BookRemover  == null)
                    {
                        Console.WriteLine("Book não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaBookRemocao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaBookRemocao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Book não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaBookRemocao == true);
             
            if (BookRemover != null)
            {
                books.Remove(BookRemover);

                Console.WriteLine("Book removido com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(); 
            }

            break;
               
        case "6":
        // Cadastrar usuário
            User User = new();
            
            do 
            {
                Console.WriteLine("---------------Cadastro de usuário-----------------");
                try
                {
                    Console.WriteLine("Digite o Name do usuário:");
                    User.Name = Console.ReadLine();

                    Console.WriteLine("Digite o email do usuário:");
                    User.Email = Console.ReadLine();

                    User.Id = contUsers++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar usuário, tente novamente! Ex:" + ex.Message);
                }
            } while (User.Id == 0);
            
            users.Add(User);
            break;
        case "7":
        // Editar usuário
            Console.WriteLine("---------------Edição de Usuários------------------");

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            users.ForEach(u => u.ShowList());
            
            User UserEditar = null;
            bool continuarConsultaUserEdicao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o Id do usuário que deseja editar:");
                    int idUserEditar = int.Parse(Console.ReadLine());
                    UserEditar = users.Find(u => u.Id == idUserEditar);

                    if (UserEditar == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUserEdicao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else
                        continuarConsultaUserEdicao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUserEdicao == true);

            bool continuarEdicaoUser = true;

            if (UserEditar !=  null && continuarConsultaUserEdicao == false)
            {
                do 
                {
                    Console.WriteLine("---------------Edição de usuário-----------------");
                    try
                    {
                        Console.WriteLine("Digite o novo Name do usuário:");
                        UserEditar.Name = Console.ReadLine();

                        Console.WriteLine("Digite o novo email do usuário:");
                        UserEditar.Email = Console.ReadLine();

                        continuarEdicaoUser = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao cadastrar usuário, tente novamente! Ex:" + ex.Message);
                    }
                } while (continuarEdicaoUser == true);

                Console.WriteLine("Usuário editado com sucesso!");
                UserEditar.Show();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
            }
            
            break;
        case "8":
        // Consultar um usuário
            Console.WriteLine("---------------Consulta de Usuários------------------");

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            User UserConsultar = null;
            bool continuarConsultaUser = true;
            do
            {
                
                try
                {
                    Console.WriteLine("Digite o email do usuário que deseja consultar:");
                    string emailUserConsultar = Console.ReadLine();
                    UserConsultar = users.Find(u => u.Email == emailUserConsultar);

                    if (UserConsultar  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUser = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUser = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUser == true);

            if( UserConsultar != null)
            {
                UserConsultar.Show();

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(); 
            }    

            break;
        case "9":
        // Listar usuários
            
            Console.WriteLine("-------------Listagem de usuários------------------");

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            users.ForEach(u => u.ShowList());
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
        case "10":
        // Remover Usuário
            
            Console.WriteLine("-------------Remoção de Usuário-------------------");

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            users.ForEach(u => u.ShowList());
            
            User UserRemover = null;
            bool continuarConsultaUserRemocao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do usuário que deseja remover:");
                    int idUserRemover = int.Parse(Console.ReadLine());
                    UserRemover = users.Find(u => u.Id == idUserRemover);

                    if (UserRemover  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUserRemocao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUserRemocao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUserRemocao == true);
             
            if (UserRemover != null)
            {
                users.Remove(UserRemover);
                Console.WriteLine("Usuário removido com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            break;
        
        case "11":
        // Realizar empréstimo
            
            
            Console.WriteLine("-------------Cadastro de empréstimo----------------");

            if (books.Count == 0)
            {
                Console.WriteLine("Não há books cadastrados, realize o cadastro e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de books:");
            books.ForEach(l => l.ShowList());

            Rent emprestimo = new(){
                Id = contRents++
            };

            bool continuarConsultaBookEmprestimo = true;
            Book BookConsultarEmprestimo = null;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do Book que desejado:");
                    int idBookEmprestimo = int.Parse(Console.ReadLine());
                    BookConsultarEmprestimo = books.Find(l => l.Id == idBookEmprestimo);

                    if (BookConsultarEmprestimo == null)
                    {
                        Console.WriteLine("Book não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaBookEmprestimo = tentarNovamente.ToUpper().Equals("S");
                    }else
                        continuarConsultaBookEmprestimo = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Book não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaBookEmprestimo == true);  

            if( BookConsultarEmprestimo != null)
            {
                emprestimo.Book = BookConsultarEmprestimo;
            } 

            if (users.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados, realize o cadastro e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            users.ForEach(u => u.ShowList());
            
            User UserConsultarEmprestimo = null;
            bool continuarConsultaUserEmprestimo = true;
            do
            {   
                try
                {
                    Console.WriteLine("Digite o ID do usuário que desejado:");
                    int idUserEmprestimo = int.Parse(Console.ReadLine());
                    UserConsultarEmprestimo = users.Find(u => u.Id == idUserEmprestimo);

                    if (UserConsultarEmprestimo  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUserEmprestimo = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUserEmprestimo = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUserEmprestimo == true);

            if( UserConsultarEmprestimo != null)
            {
                emprestimo.User = UserConsultarEmprestimo;
            }   

            do 
            {
                Console.WriteLine("Escolha um prazo de devolução:");
                Console.WriteLine("1 - 7 dias");
                Console.WriteLine("2 - 15 dias");
                Console.WriteLine("3 - 30 dias");

                string opcaoData = Console.ReadLine();

                emprestimo.ReturnDate = opcaoData switch
                {
                    "1" => DateTime.Now.AddDays(7),
                    "2" => DateTime.Now.AddDays(15),
                    "3" => DateTime.Now.AddDays(30),
                    _ => DateTime.MinValue,
                };

            } while (emprestimo.ReturnDate == DateTime.MinValue);

            if (emprestimo.ReturnDate != DateTime.MinValue)
            {
                Console.WriteLine("Empréstimo realizado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            rents.Add(emprestimo);
            break;
        case "12":
        // Devolver Book
            bool devolvido = false;
            string mensagem = "";
            Console.WriteLine("------------Devolução de empréstimo----------------");

            if (rents.Count == 0)
            {
                Console.WriteLine("Não há empréstimos, realize um e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de empréstimos:"); 
            rents.ForEach( e => e.Show());
            
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do empréstimo:");
                    int emprestimoId = int.Parse(Console.ReadLine());
                    mensagem = rents.Find(e => e.Id == emprestimoId).ReturnDate > DateTime.Now ? "Empréstimo no prazo" : "Empréstimo atrasado";
                    rents.Remove(rents.Find(e => e.Id == emprestimoId));
                    devolvido = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Empréstimo não encontrado, tente novamente!");
                    Console.WriteLine("Deseja tentar novamente? (S/N)");
                    string tentarNovamente = Console.ReadLine();
                    devolvido = tentarNovamente.ToUpper().Equals("N");
                }
                
            } while (devolvido == false);
           
            if (devolvido == true)
            {   
                Console.WriteLine("-------------Devolução de empréstimo----------------");
                Console.WriteLine(mensagem);
                Console.WriteLine("Book devolvido com sucesso!");
                Console.WriteLine("Lista de empréstimos atualizada:");
                rents.ForEach( e => e.Show());   
            }

            break;
        case "13":
        // Listar empréstimos
            
            Console.WriteLine("-------------Listagem de empréstimos--------------");

            if (rents.Count == 0)
            {
                Console.WriteLine("Não há empréstimos, realize um e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
           
            rents.ForEach( e => e.Show());

            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadKey();
            break;
        
        case "14":
        // Sair
            stop = true;
            break;
        default:
            
            Console.WriteLine("Invalid option");
            option = "";
            break;  
    }

} while (stop == false);

