import { Button, Paper, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Template } from "../components/Template";
import { IQuestionario } from "./QuestionarioUsuario";

const questionarios: IQuestionario[] = [
  {
    id: "1",
    descricao: "Avaliação do curso",
    vigente: true,
  },
  {
    id: "2",
    descricao: "Avaliação da infraestrutura",
    vigente: true,
  },
  {
    id: "3",
    descricao: "Avaliação dos docentes",
    vigente: false,
  },
];

export const QuestionariosUsuario = () => {
  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        Questionários
      </Typography>
      {questionarios.map((q) => (
        <QuestionarioItem key={q.id} questionario={q} />
      ))}
    </Template>
  );
};

interface IQuestionarioItem {
  questionario: IQuestionario;
}

const QuestionarioItem = ({ questionario }: IQuestionarioItem) => {
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
        {questionario.descricao}
      </Typography>
      <Button
        variant="contained"
        disabled={!questionario.vigente}
        onClick={() => navigate("/questionario")}
      >
        Responder
      </Button>
    </Paper>
  );
};
