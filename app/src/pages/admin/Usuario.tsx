import {
  Button,
  Checkbox,
  FormControlLabel,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Template } from "../../components/Template";
import { api } from "../../services/Api";
import { IGrupoUsuario } from "./GrupoUsuarios";

interface IUsuarioCadastro {
  id?: string;
  login: string;
  senha: string;
  nome: string;
  sobrenome: string;
  dataNascimento: string;
  isAdmin: boolean;
  grupoUsuarioId: string;
}

export const Usuario = () => {
  const { usuarioId } = useParams();
  const [usuario, setUsuario] = useState<IUsuarioCadastro>();
  const [isLoaded, setIsLoaded] = useState(false);

  useEffect(() => {
    const controller = new AbortController();
    api
      .get("api/User/usuarios", {
        signal: controller.signal,
      })
      .then((res) => {
        const usuarios = res.data.data;
        const usuarioAtual = usuarios.find(
          (u: IUsuarioCadastro) => u.id === usuarioId
        );
        setUsuario(usuarioAtual);
        setIsLoaded(true);
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
        Usuário
      </Typography>
      {isLoaded ? <UsuarioForm usuario={usuario} /> : null}
    </Template>
  );
};

interface IUsuarioFormProps {
  usuario?: IUsuarioCadastro;
}

const UsuarioForm = ({ usuario }: IUsuarioFormProps) => {
  const isUpdate = Boolean(usuario);
  const [login, setLogin] = useState<string>(usuario?.login ?? "");
  const [password, setPassword] = useState<string>(usuario?.senha ?? "");
  const [nome, setNome] = useState<string>(usuario?.nome ?? "");
  const [sobrenome, setSobrenome] = useState<string>(usuario?.sobrenome ?? "");
  const [dataNascimento, setDataNascimento] = useState<string>(
    usuario?.dataNascimento.substring(0, 10) ??
      new Date().toISOString().substring(0, 10)
  );
  const [grupoUsuario, setGrupoUsuario] = useState<string>(
    usuario?.grupoUsuarioId ?? ""
  );
  const [gruposDeUsuario, setGruposDeUsuario] = useState<IGrupoUsuario[]>([]);
  const [isAdmin, setIsAdmin] = useState<boolean>(usuario?.isAdmin ?? false);

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<boolean>(false);
  const navigate = useNavigate();

  useEffect(() => {
    const controller = new AbortController();
    api
      .get("api/User/grupo-usuario/lista", {
        signal: controller.signal,
      })
      .then((res) => {
        setGruposDeUsuario(res.data);
      });

    return () => {
      controller.abort();
    };
  }, []);

  const handleSubmit = (e: any) => {
    e.preventDefault();
    const usuarioCadastro: IUsuarioCadastro = {
      login,
      senha: password,
      nome,
      sobrenome,
      dataNascimento: new Date(dataNascimento).toISOString(),
      isAdmin,
      grupoUsuarioId: grupoUsuario,
    };
    setError(false);
    setIsLoading(true);
    if (isUpdate) {
      api
        .put(`api/User/cadastro/${usuario?.id}`, usuarioCadastro)
        .then((res) => {
          navigate("/", { replace: true });
        })
        .catch(() => {
          setError(true);
        })
        .finally(() => {
          setIsLoading(false);
        });
    } else {
      api
        .post("api/User/cadastro", usuarioCadastro)
        .then((res) => {
          navigate("/", { replace: true });
        })
        .catch(() => {
          setError(true);
        })
        .finally(() => {
          setIsLoading(false);
        });
    }
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
            minLength: "4",
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
        <InputLabel>Grupo de usuário</InputLabel>
        <Select
          value={grupoUsuario}
          required
          displayEmpty
          onChange={(e) => setGrupoUsuario(e.target.value)}
        >
          {gruposDeUsuario.map((g) => (
            <MenuItem key={g.id} value={g.id}>
              {g.descricao}
            </MenuItem>
          ))}
        </Select>
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
          {isUpdate ? "Atualizar" : "Salvar"}
        </Button>
      </Paper>
    </form>
  );
};
