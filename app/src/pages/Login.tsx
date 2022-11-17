import {
  Box,
  Button,
  Paper,
  TextField,
  Typography,
  useTheme,
} from "@mui/material";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Logo } from "../components/Logo";
import useUser from "../hooks/useUser";
import { api } from "../services/Api";

export const Login = () => {
  const theme = useTheme();
  const navigate = useNavigate();
  const { signIn } = useUser();
  const [login, setLogin] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<boolean>(false);

  const handleSubmit = (e: any) => {
    e.preventDefault();
    setError(false);
    setIsLoading(true);
    api
      .post("api/User/login", {
        login,
        senha: password,
      })
      .then((res) => {
        signIn(res.data.data);
        navigate("/", { replace: true });
      })
      .catch((err) => {
        console.log(err);

        setError(true);
      })
      .finally(() => {
        setIsLoading(false);
      });
  };

  return (
    <Box
      sx={{
        display: "flex",
        height: "100vh",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: theme.palette.primary.main,
      }}
    >
      <form onSubmit={handleSubmit}>
        <Paper
          sx={{
            display: "flex",
            flexDirection: "column",
            padding: "1rem",
            gap: "1rem",
          }}
        >
          <Logo primary sx={{ alignSelf: "center" }} />
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
            onChange={(e) => setPassword(e.target.value)}
            type={"password"}
            inputProps={{
              minLength: "3",
              maxLength: "10",
            }}
          />
          {error ? (
            <Typography variant="body1" component="div" color="error">
              Senha ou usuário inválido
            </Typography>
          ) : null}
          <Button variant="contained" type="submit" disabled={isLoading}>
            Logar
          </Button>
        </Paper>
      </form>
    </Box>
  );
};
