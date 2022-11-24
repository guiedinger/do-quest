import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import { Button, Paper, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Template } from "../components/Template";
import { api } from "../services/Api";

interface IUsuario {
  login: string;
  senha: string;
  nome: string;
  sobrenome: string;
  dataNascimento: string;
  grupoUsuario: any;
  respondeuAoQuestionario: boolean;
  isAdmin: boolean;
  id: string;
}

const usuarios: IUsuario[] = [];

export const Usuarios = () => {
  const [usuarios, setUsuarios] = useState<IUsuario[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const controller = new AbortController();
    api
      .get("api/User/usuarios", {
        signal: controller.signal,
      })
      .then((res) => {
        setUsuarios(res.data.data);
      });

    return () => {
      controller.abort();
    };
  }, []);

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
        onClick={() => navigate(`/usuario`)}
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
