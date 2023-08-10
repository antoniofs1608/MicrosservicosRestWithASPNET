# **MicrosservicosRestWithASPNET**
Arquitetura de Microserviços ASP.NET 6 e C#, MySQL, MySQL Workbench, HeidiSQL, Postman API, Git, Git Bash, Github, Docker e Visual Studio 2022

## **Serviços RESTful: verbos HTTP**
Este artigo contém um resumo dos cinco principais verbos HTTP utilizados nas ações CRUD de um serviço REST

Quando começamos a desenvolver – ou consumir - nossos primeiros serviços RESTful, a primeira coisa que precisamos entender é o papel dos verbos HTTP dentro do contexto REST.
Este artigo pode lhe servir como referência de consulta para iniciar seus trabalhos com os verbos HTTP em serviços REST.


### **Fundamentos**
A ideia geral é a seguinte: seu serviço vai prover uma url base e os verbos HTTP vão indicar qual ação está sendo requisitada pelo consumidor do serviço.

Por exemplo, considerando a URL www.dominio.com/rest/person/, se enviarmos para ela uma requisição HTTP utilizando o verbo GET, provavelmente obteremos como resultado uma listagem de registros (people, nesse caso). Por outro lado, se utilizarmos o verbo POST, provalmente estaremos tentando adicionar um novo registro, cujos dados serão enviados no corpo da requisição.

Da mesma forma, a URL www.dominio.com/rest/person/1, por exemplo, poderia ser usada para diferentes finalidades, dependendo do verbo enviado na requisição. No caso do GET, essa URL provavelmente deveria nos retornar o registro de ID 1 (nesse caso, a person de ID = 1). Já o verbo DELETE indicaria que desejamos remover esse registro.

Repare que a URL se mantém – o verbo indica o que estamos fazendo de fato. Por exemplo, não precisamos disponibilizar no serviço uma URL como /person/listar ou /person/remover/1.


### **Exemplo prático:**
Os exemplos a seguir foram feitos utilizando a extensão Postman, do Google Chrome, para comunicar com a API, criada no curso Criando serviços RESTful em .NET. Para saber mais sobre esse serviço assista também ao curso O que é RESTful. Contudo, os conceitos apresentados aqui podem ser aplicados a outras tecnologias, uma vez que REST é um padrão e independe de linguagem.

#### **Verbo GET:**
- Sem passagem de ID: vai retornar todas as person (ou as people mais recentes, isso cabe a regra de negócio da aplicação).
- Com passagem de ID: vai retornar a person com ID especificado.

#### **Verbo POST:**
Normalmente usado sem passagem de parâmetro – usado para criar uma nova person.

#### **Verbo DELETE:**
Usado para remover o recurso (por exemplo uma person): utilize com passagem de ID.

#### **Verbo PUT:**
Normalmente usado com parâmetro; Use para editar o recurso – neste exemplo, uma peson.

***Nota:***
*A literatura indica que o verbo PUT deve passar todos os dados do recurso preenchidos, independente de quais dados você de fato editou. Por exemplo, digamos que sua classe person possui os atributos id, FirstName, LastName, Address e Gender – e você editou apenas o FirstNam. A documentação indica que você deve passar ambos os atributos preenchidos para o serviço (mesmo só tendo editado o FirstName).
Para resolver essa questão de forma elegante a comunidade adotou, por convenção, o uso de um quinto verbo HTTP: PATCH.

#### **Verbo PATCH:**
Usado para editar o recurso sem a necessidade de enviar todos os atributos – o consumidor envia apenas aquilo que de fato foi alterado (mais o ID como parâmetro, para que o serviço saiba o que vai ser alterado).


### **Padrões de resposta do serviço**
A documentação indica que o serviço pode retornar o resultado em diversos formatos – JSON, XML, texto plano, etc. Contudo, atualmente o formato mais adotado tem sido o JSON, por seu formato leve, legível e sua fácil interpretação por diversas tecnologias.

Além disso, o protocolo HTTP dispõe de diveros códigos (ou status) que devem ser incluídos na resposta, indicando o resultado do processamento.

Os códigos iniciados em "2" indicam que a operação foi bem sucedida. Nessa categoria temos, por exemplo, código 200 (OK), iniciando que o método foi executado com sucesso; 201 (Created) quando um novo recurso foi criado no servidor; e 204 (No Content) quando a requisição foi bem sucedida, mas o servidor não precisa retornar nenhum conteúdo para o cliente.

Já os códigos iniciados em "4" indicam algum erro que provavelmente partiu do cliente. Por exemplo, o código 400 (Bad Request) indica que a requisição não pôde ser compreendida pelo servidor, enquanto o 404 (Not Found) indica que o recurso não foi localizado.

Há, ainda, os códigos que indicam erro do lado do servidor. Nesse caso, eles iniciam com "5", como o 500 (Internal Server Error), que indica que ocorreu um erro internamente no servidor que o impediu de processar e responder adequdamente a requisição.

Pra conhecer todos os status do HTTP, você pode consultar a [especificação do protocolo](https://www.rfc-editor.org/rfc/rfc9110.html).

### **Diferenças entre PUT e POST**
Encontramos na literatura indicações de que apenas três verbos são suficientes para um CRUD completo: GET, DELETE e PUT – sendo o PUT utilizado para criar ou editar um recurso.

Interpretando a documentação, temos o seguinte: PUT é usado para criar ou editar um recurso, enquanto POST pode ser utilizado para qualquer coisa, cabendo ao back-end a definição dessa semântica.

O mundo não-acadêmico, no entanto, adotou por convenção o uso do POST para incluir e do PUT para alterar – e em situações de programação mais elegantes, também o uso de PATCH para editar parcialmente.
