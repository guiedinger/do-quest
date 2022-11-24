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

interface IUsuarioCadastro {
  login: string;
  senha: string;
  nome: string;
  sobrenome: string;
  dataNascimento: string;
  isAdmin: boolean;
  // grupoUsuario: any;
  // respondeuAoQuestionario: boolean;
  // id: string;
}

export const QuestionarioAdmin = () => {
  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        Usuário
      </Typography>
      <QuestionarioAdminForm />
    </Template>
  );
};

const QuestionarioAdminForm = () => {
  const [login, setLogin] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [nome, setNome] = useState<string>("");
  const [sobrenome, setSobrenome] = useState<string>("");
  const [dataNascimento, setDataNascimento] = useState<string>(
    new Date().toISOString().substring(0, 10)
  );
  const [isAdmin, setIsAdmin] = useState<boolean>(false);

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<boolean>(false);
  const navigate = useNavigate();

  const handleSubmit = (e: any) => {
    e.preventDefault();
    const usuario: IUsuarioCadastro = {
      login,
      senha: password,
      nome,
      sobrenome,
      dataNascimento: new Date(dataNascimento).toISOString(),
      isAdmin,
    };
    setError(false);
    setIsLoading(true);
    api
      .post("api/User/cadastro", usuario)
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
          label="Login"
          value={login}
          inputProps={{
            minLength: "3",
            maxLength: "20",
          }}
          onChange={(e) => setLogin(e.target.value)}
        />
        <TextField
          required
          label="Senha"
          value={password}
          inputProps={{
            minLength: "3",
            maxLength: "20",
          }}
          onChange={(e) => setPassword(e.target.value)}
        />
        <TextField
          required
          label="Nome"
          value={nome}
          inputProps={{
            minLength: "3",
            maxLength: "20",
          }}
          onChange={(e) => setNome(e.target.value)}
        />
        <TextField
          required
          label="Sobrenome"
          value={sobrenome}
          inputProps={{
            minLength: "3",
            maxLength: "20",
          }}
          onChange={(e) => setSobrenome(e.target.value)}
        />
        <TextField
          required
          label="Data de nascimento"
          value={dataNascimento}
          type={"date"}
          onChange={(e) => setDataNascimento(e.target.value)}
        />
        <FormControlLabel
          control={
            <Checkbox
              name="administrador"
              checked={isAdmin}
              onChange={() => {
                setIsAdmin(!isAdmin);
              }}
            />
          }
          label="Administrador"
        />
        {error ? (
          <Typography variant="body1" component="div" color="error">
            Problema ao salvar usuário
          </Typography>
        ) : null}
        <Button variant="contained" type="submit" disabled={isLoading}>
          Salvar
        </Button>
      </Paper>
    </form>
  );
};
