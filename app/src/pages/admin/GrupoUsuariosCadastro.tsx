import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import {
  Button,
  Checkbox,
  FormControlLabel,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Template } from "../../components/Template";
import { api } from "../../services/Api";

interface IGrupoUsuarioCadastro {
  descricao: string;
}

export const GrupoUsuariosCadastro = () => {
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
      <GrupoUsuarioForm />
    </Template>
  );
};

const GrupoUsuarioForm = () => {
  const [descricao, setDescricao] = useState<string>("");

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<boolean>(false);
  const navigate = useNavigate();

  const handleSubmit = (e: any) => {
    e.preventDefault();
    const grupoUsuario: IGrupoUsuarioCadastro = {
      descricao,
    };
    setError(false);
    setIsLoading(true);
    api
      .post("api/User/grupo-usuario", grupoUsuario)
      .then((res) => {
        navigate("/", { replace: true });
      })
      .catch(() => {
        setError(true);
      })
      .finally(() => {
        setIsLoading(false);
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <Paper
        sx={{
          display: "flex",
          flexDirection: "column",
          padding: "1rem",
          gap: "1rem",
        }}
      >
        <TextField
          required
          label="Descrição"
          value={descricao}
          inputProps={{
            minLength: "3",
            maxLength: "40",
          }}
          onChange={(e) => setDescricao(e.target.value)}
        />
        {error ? (
          <Typography variant="body1" component="div" color="error">
            Problema ao salvar grupo de usuários
          </Typography>
        ) : null}
        <Button variant="contained" type="submit" disabled={isLoading}>
          Salvar
        </Button>
      </Paper>
    </form>
  );
};
