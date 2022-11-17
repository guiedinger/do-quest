import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import { Button, Paper, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Template } from "../components/Template";

interface IUsuario {
  id: string;
  login: string;
  nome: string;
  senha: string;
  sobrenome: string;
  dataNascimento: Date;
}

const usuarios: IUsuario[] = [
  {
    id: "1",
    login: "admin",
    senha: "123",
    nome: "Guilherme",
    sobrenome: "Edinger",
    dataNascimento: new Date(),
  },
  {
    id: "2",
    login: "admin1",
    senha: "123",
    nome: "Jeferson",
    sobrenome: "Michelin",
    dataNascimento: new Date(),
  },
  {
    id: "3",
    login: "admin2",
    senha: "123",
    nome: "Pedro",
    sobrenome: "Henrique",
    dataNascimento: new Date(),
  },
  {
    id: "4",
    login: "admin3",
    senha: "123",
    nome: "Thomas",
    sobrenome: "Toniolo",
    dataNascimento: new Date(),
  },
];

export const Usuarios = () => {
  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        Usuários
      </Typography>
      <Button
        variant="contained"
        endIcon={<AddIcon />}
        sx={{ alignSelf: "flex-end", margin: "1rem" }}
      >
        Novo usuário
      </Button>
      {usuarios.map((u) => (
        <UsuarioItem key={u.id} usuario={u} />
      ))}
    </Template>
  );
};

interface IUsuarioItem {
  usuario: IUsuario;
}

const UsuarioItem = ({ usuario }: IUsuarioItem) => {
  const navigate = useNavigate();
  return (
    <Paper
      sx={{
        padding: "1rem",
        marginTop: "1rem",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <Typography variant="body1" component="div">
        {`${usuario.sobrenome}, ${usuario.nome}`}
      </Typography>
      <Button
        variant="contained"
        endIcon={<EditIcon />}
        onClick={() => navigate(`/usuario/${usuario.id}`)}
      >
        Editar
      </Button>
    </Paper>
  );
};
