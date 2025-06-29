# Agenda Simples - App .NET MAUI

## Visão Geral

App simples para gerenciar agendamentos semanais com alunos, focado em dispositivos móveis (Android e iOS), com interface única e armazenamento local.

---

## Requisitos

- Cadastro de agendamentos (data/hora + aluno)
- Persistência local dos agendamentos com repetição semanal automática
- Visualização dos agendamentos agrupados por dia da semana
- Notificações locais (implementação futura)
- Notificações por e-mail para alunos (implementação futura)

---

## Estrutura do Projeto
```shell
MeuApp/
├── Properties/ # Configurações do projeto
├── Platforms/ # Código específico para cada plataforma (Android, iOS, etc)
├── Resources/ # Imagens, fontes, estilos
├── Model/ # Entidades e regras de negócio (ex: Agendamento)
├── View/ # Telas do app (.xaml + code-behind)
├── Services/ # Serviços para persistência, notificações, etc
├── App.xaml # Configurações globais do app
├── AppShell.xaml # Roteamento e navegação
└── MauiProgram.cs # Configuração e injeção de dependências
```
---

## Tecnologias e Ferramentas

- [.NET MAUI 8.0 (LTS)](https://dotnet.microsoft.com/en-us/platform/maui)  
- SQLite para persistência local (via `sqlite-net-pcl`)  
- UI única para Android e iOS usando XAML  
- Notificações locais (futuras via plugin ou código nativo em `Platforms/`)  
- Navegação via `AppShell`

---

## Considerações Técnicas

- UI compartilhada e responsiva para dispositivos móveis, sem múltiplas UIs nativas  
- Persistência local totalmente cross-platform  
- Notificações locais requerem código específico para Android/iOS, portanto implementadas ao final  
- E-mails para alunos serão enviados via serviço externo no futuro (fora do escopo inicial)

---

## Próximos passos sugeridos

1. Modelar entidade `Agendamento` com campos básicos (aluno, data/hora, repetição)  
2. Implementar serviço de persistência local usando SQLite  
3. Criar a UI da página principal com lista de agendamentos agrupados por dia  
4. Adicionar funcionalidade de inserir novo agendamento  
5. Implementar notificações locais (última etapa)  

---

## Contato

Desenvolvido por [Samuel Araujo De Oliveira](https://github.com/x99oly)  

