import { Button, Paper, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Template } from "../../components/Template";

export const HomeAdmin = () => {
  const navigate = useNavigate();

  return (
    <Template>
      <Paper
        sx={{
          display: "flex",
          flexDirection: "column",
          padding: "1rem",
          gap: "1rem",
        }}
      >
        <Typography
          variant="h6"
          color="primary"
          component="div"
          sx={{ textAlign: "center" }}
        >
          Home
        </Typography>
        <Button variant="contained" onClick={() => navigate(`/usuarios`)}>
          Usuários
        </Button>
        <Button variant="contained" onClick={() => navigate(`/grupo-usuarios`)}>
          Grupo de Usuários
        </Button>
        <Button variant="contained" onClick={() => navigate(`/questionarios`)}>
          Questionários
        </Button>
      </Paper>
    </Template>
  );
};
