import {
  Button,
  FormControlLabel,
  Paper,
  Radio,
  RadioGroup,
  TextField,
  Typography,
} from "@mui/material";
import { Template } from "../components/Template";

export interface IQuestionario {
  id: string;
  descricao: string;
  vigente: boolean;
  perguntas?: IPergunta[];
}

export interface IPergunta {
  id: string;
  descricao: string;
  tipo: "Dissertativa" | "Objetiva";
  alternativas?: IAlternativa[];
}

export interface IAlternativa {
  codigo: string;
  descricao: string;
}

export const Questionario = () => {
  const questionarioAtual: IQuestionario = {
    id: "1",
    descricao: "Avaliação do curso",
    vigente: true,
    perguntas: [
      {
        id: "1",
        descricao: "Descreva o que deve melhorar no curso:",
        tipo: "Dissertativa",
      },
      {
        id: "2",
        descricao: "Qual a sua satisfação com o curso?",
        tipo: "Objetiva",
        alternativas: [
          {
            codigo: "I",
            descricao: "Insatisfeito",
          },
          {
            codigo: "N",
            descricao: "Neutro",
          },
          {
            codigo: "S",
            descricao: "Satisfeito",
          },
        ],
      },
    ],
  };

  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        {questionarioAtual.descricao}
      </Typography>
      {questionarioAtual.perguntas &&
        questionarioAtual.perguntas.map((p) => (
          <PerguntaItem key={p.id} pergunta={p} />
        ))}
      <Button
        variant="contained"
        sx={{ margin: "1rem", alignSelf: "flex-end" }}
      >
        Responder
      </Button>
    </Template>
  );
};

interface IPerguntaItem {
  pergunta: IPergunta;
}

const PerguntaItem = ({ pergunta }: IPerguntaItem) => {
  return (
    <Paper
      sx={{
        padding: "1rem",
        marginTop: "1rem",
        display: "flex",
        flexDirection: "column",
        gap: "1rem",
      }}
    >
      <Typography variant="body1" component="div">
        {pergunta.descricao}
      </Typography>
      {pergunta.tipo === "Dissertativa" ? (
        <TextField label="Resposta" multiline />
      ) : null}
      {pergunta.tipo === "Objetiva" ? (
        <RadioGroup>
          {pergunta.alternativas &&
            pergunta.alternativas.map((a) => (
              <FormControlLabel
                value={a.codigo}
                control={<Radio />}
                label={a.descricao}
              />
            ))}
        </RadioGroup>
      ) : null}
    </Paper>
  );
};
