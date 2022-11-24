import AddIcon from "@mui/icons-material/Add";
import { Button, Paper, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Template } from "../../components/Template";
import { api } from "../../services/Api";

export interface IGrupoUsuario {
  id: string;
  descricao: string;
}

export const GrupoUsuarios = () => {
  const [grupos, setGrupos] = useState<IGrupoUsuario[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const controller = new AbortController();
    api
      .get("api/User/grupo-usuario/lista", {
        signal: controller.signal,
      })
      .then((res) => {
        setGrupos(res.data);
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
        Grupo de Usuários
      </Typography>
      <Button
        variant="contained"
        endIcon={<AddIcon />}
        sx={{ alignSelf: "flex-end", margin: "1rem" }}
        onClick={() => navigate(`/grupo-usuarios/cadastro`)}
      >
        Novo grupo
      </Button>
      {grupos.map((u) => (
        <GrupoUsuarioItem key={u.id} grupo={u} />
      ))}
    </Template>
  );
};

interface IGrupoUsuarioItem {
  grupo: IGrupoUsuario;
}

const GrupoUsuarioItem = ({ grupo: grupo }: IGrupoUsuarioItem) => {
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
        {grupo.descricao}
      </Typography>
    </Paper>
  );
};
